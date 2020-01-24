using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
    public enum LineNumberStyle
    {
        OffsetColors, Boxed
    }

    public sealed class TFiveLineNumber : Control
    {
        private BufferedGraphics _bufferedGraphics;
        private readonly BufferedGraphicsContext _bufferContext = BufferedGraphicsManager.Current;
        private readonly RichTextBox _richTextBox;
        private Brush _fontBrush;
        private Brush _offsetBrush = new SolidBrush(Color.DodgerBlue);
        private LineNumberStyle _style;
        private readonly Pen _penBoxedLine = Pens.LightGray;
        private float _fontHeight;
        private const float FontModifier = 0.09f;
        private bool _speedBump;
        private const int DrawingOffset = 1;
        private int _lastYPos = -1, _dragDistance, _lastLineCount;
        private int _numPadding = 3;


        public TFiveLineNumber(RichTextBox plainTextBox)
        {
            _richTextBox = plainTextBox;
            plainTextBox.TextChanged += _richTextBox_TextChanged;
            plainTextBox.FontChanged += _richTextBox_FontChanged;
            plainTextBox.VScroll += _richTextBox_VScroll;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            Size = new Size(10, 10);
            base.Dock = DockStyle.Left;
            BackColor = Color.FromArgb(240, 240, 240);
            OffsetColor = Color.FromArgb(150, 150, 255);
            Style = LineNumberStyle.OffsetColors;


            _fontBrush = new SolidBrush(Color.FromArgb(0, 100, 255));

            SetFontHeight();
            UpdateBackBuffer();
            SendToBack();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button.Equals(MouseButtons.Left) && ScrollSpeed != 0)
            {
                _lastYPos = Cursor.Position.Y;
                Cursor = Cursors.NoMoveVert;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            SetControlWidth();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left) && ScrollSpeed != 0)
            {
                _dragDistance += Cursor.Position.Y - _lastYPos;

                if (_dragDistance > _fontHeight)
                {
                    var selectionStart = _richTextBox.GetFirstCharIndexFromLine(NextLineDown);
                    _richTextBox.Select(selectionStart, 0);
                    _dragDistance = 0;
                }
                else if (_dragDistance < _fontHeight * -1)
                {
                    var selectionStart = _richTextBox.GetFirstCharIndexFromLine(NextLineUp);
                    _richTextBox.Select(selectionStart, 0);
                    _dragDistance = 0;
                }

                _lastYPos = Cursor.Position.Y;
            }
        }

        #region Functions
        private void UpdateBackBuffer()
        {
            if (Width <= 0) return;
            _bufferContext.MaximumBuffer = new Size(Width + 1, Height + 1);
            _bufferedGraphics = _bufferContext.Allocate(CreateGraphics(), ClientRectangle);
        }

        private int GetPositionOfRtbLine(int lineNumber)
        {
            var index = _richTextBox.GetFirstCharIndexFromLine(lineNumber);
            var pos = _richTextBox.GetPositionFromCharIndex(index);
            return index.Equals(-1) ? -1 : pos.Y;
        }

        private void SetFontHeight()
        {
            Font = new Font(_richTextBox.Font.FontFamily, _richTextBox.Font.Size +
                FontModifier, _richTextBox.Font.Style);

            _fontHeight = _bufferedGraphics.Graphics.MeasureString("123ABC", Font).Height;
        }

        private void SetControlWidth()
        {

            if (_richTextBox.Lines.Length.Equals(0))
            {
                Width = 0;
            }
            else
            {
                Width = WidthOfWidestLineNumber + _numPadding * 2;
            }


            Invalidate(false);
        }
        #endregion

        #region Event Handlers
        private void _richTextBox_FontChanged(object sender, EventArgs e)
        {
            SetFontHeight();
            SetControlWidth();
        }

        private void _richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_richTextBox.WordWrap || !_lastLineCount.Equals(_richTextBox.Lines.Length))
            {
                SetControlWidth();
            }

            _lastLineCount = _richTextBox.Lines.Length;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _fontBrush = new SolidBrush(ForeColor);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateBackBuffer();
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

            _bufferedGraphics.Graphics.Clear(BackColor);

            var firstIndex = _richTextBox.GetCharIndexFromPosition(Point.Empty);
            var firstLine = _richTextBox.GetLineFromCharIndex(firstIndex);
            var bottomLeft = new Point(0, ClientRectangle.Height);
            var lastIndex = _richTextBox.GetCharIndexFromPosition(bottomLeft);
            var lastLine = _richTextBox.GetLineFromCharIndex(lastIndex);

            for (var i = firstLine; i <= lastLine + 1; i++)
            {
                var charYPos = GetPositionOfRtbLine(i);
                if (charYPos.Equals(-1)) continue;
                float yPos = GetPositionOfRtbLine(i) + DrawingOffset;

                switch (_style)
                {
                    case LineNumberStyle.OffsetColors:
                        {
                            if (i % 2 == 0)
                            {
                                _bufferedGraphics.Graphics.FillRectangle(_offsetBrush, 0, yPos, Width,
                                    _fontHeight * FontModifier * 10);
                            }

                            break;
                        }
                    case LineNumberStyle.Boxed:
                        {
                            var endPos = new PointF(Width, yPos + _fontHeight - DrawingOffset * 3);
                            var startPos = new PointF(0, yPos + _fontHeight - DrawingOffset * 3);
                            _bufferedGraphics.Graphics.DrawLine(_penBoxedLine, startPos, endPos);
                            break;
                        }
                }

                var stringPos = new PointF(_numPadding, yPos);
                var line = (i + 1).ToString(CultureInfo.InvariantCulture);
                _bufferedGraphics.Graphics.DrawString(line, Font, _fontBrush, stringPos);

            }

            _bufferedGraphics.Render(pevent.Graphics);
        }

        private void _richTextBox_VScroll(object sender, EventArgs e)
        {
            // Decrease the paint calls by one half when there is more than 3000 lines
            if (_richTextBox.Lines.Length > 3000 && _speedBump)
            {
                _speedBump = !_speedBump;
                return;
            }

            Invalidate(false);
        }
        #endregion

        #region Properties
        private int NextLineDown
        {
            get
            {
                var yPos = _richTextBox.ClientSize.Height + (int)(_fontHeight * ScrollSpeed + 0.5f);
                var topPos = new Point(0, yPos);
                var index = _richTextBox.GetCharIndexFromPosition(topPos);
                return _richTextBox.GetLineFromCharIndex(index);
            }
        }

        private int NextLineUp
        {
            get
            {
                var topPos = new Point(0, (int)(_fontHeight * (ScrollSpeed * -1) + -0.5f));
                var index = _richTextBox.GetCharIndexFromPosition(topPos);
                return _richTextBox.GetLineFromCharIndex(index);
            }
        }


        private int WidthOfWidestLineNumber
        {
            get
            {
                var strNumber = (_richTextBox.Lines.Length).ToString(CultureInfo.InvariantCulture);
                if (_bufferedGraphics.Graphics == null) return 1;
                var size = _bufferedGraphics.Graphics.MeasureString(strNumber, _richTextBox.Font);
                return (int)(size.Width + 0.5);

            }
        }

        [Category("Appearance")]
        private LineNumberStyle Style
        {
            set
            {
                _style = value;
                Invalidate(false);
            }
        }

        [Category("Appearance")]
        private Color OffsetColor
        {
            set
            {
                _offsetBrush = new SolidBrush(value);
                Invalidate(false);
            }
        }




        [Browsable(false)]
        public override DockStyle Dock
        {
            get => base.Dock;
            set => base.Dock = value;
        }

        [Category("Behavior")]
        private int ScrollSpeed { get; } = 5;

        #endregion
    }
}
