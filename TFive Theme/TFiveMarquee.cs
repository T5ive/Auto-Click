using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
    public enum ScrollSpeed { Slow, Medium, Fast };

    public class TFiveMarquee : Control
    {
        private readonly Timer _tmrAnimate = new Timer();
        private BufferedGraphics _bufGraphics;
        private readonly BufferedGraphicsContext _bufContext = BufferedGraphicsManager.Current;
        private PointF _textPos;
        private Brush _brush;
        private ScrollSpeed _scrollSpeed = ScrollSpeed.Fast;

        public TFiveMarquee()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            SetDefaults();
            UpdateBackBuffer();
            CenterMarquee();

            _tmrAnimate.Interval = 1;
            _tmrAnimate.Tick += _tmrAnimate_Tick;
            _tmrAnimate.Start();
        }

        private void SetDefaults()
        {
            base.BackColor = Color.FromArgb(240, 240, 240);
            base.Font = new Font(Font.FontFamily, 50f);
            base.ForeColor = Color.FromArgb(0, 100, 255);
            Size = new Size(500, 100);
            _brush = new SolidBrush(ForeColor);
        }

        private void UpdateBackBuffer()
        {
            if (Width > 0 && Height > 0)
            {
                _bufContext.MaximumBuffer = new Size(Width + 1, Height + 1);
                _bufGraphics = _bufContext.Allocate(CreateGraphics(), ClientRectangle);
                _bufGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        private void CenterMarquee()
        {
            float marqueeHeight = GetStringSize().Height;
            float yPos = (Height / 2f) - (marqueeHeight / 2f);
            _textPos = new PointF(_textPos.X, yPos);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateBackBuffer();
            CenterMarquee();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _bufGraphics.Graphics.Clear(BackColor);

            if (_textPos.X >= Width)
            {
                float xPos = -GetStringSize().Width;
                _textPos = new PointF(xPos, _textPos.Y);
            }

            _textPos = new PointF(_textPos.X + 2, _textPos.Y);
            _bufGraphics.Graphics.DrawString(Text, Font, _brush, _textPos);
            _bufGraphics.Render(e.Graphics);
        }

        private void _tmrAnimate_Tick(object sender, EventArgs e)
        {
            Invalidate(false);
        }

        private SizeF GetStringSize()
        {
            if (_bufGraphics == null)
                return SizeF.Empty;

            return _bufGraphics.Graphics.MeasureString(Text, Font);
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                _brush = new SolidBrush(value);
            }
        }

        [Category("Behavior")]
        [DefaultValue(ScrollSpeed.Fast)]
        public ScrollSpeed ScrollingSpeed
        {
            get { return _scrollSpeed; }
            set
            {
                _scrollSpeed = value;

                switch (_scrollSpeed)
                {
                    case ScrollSpeed.Fast: _tmrAnimate.Interval = 1; break;
                    case ScrollSpeed.Medium: _tmrAnimate.Interval = 30; break;
                    case ScrollSpeed.Slow: _tmrAnimate.Interval = 40; break;
                }
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                CenterMarquee();
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                CenterMarquee();
            }
        }
    }
}
