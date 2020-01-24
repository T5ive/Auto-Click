using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TFive
{

    [DefaultEvent("TextChanged")]
    public sealed class TFiveTextBox : Control
    {
        public TextBox TB
        {
            [CompilerGenerated]
            get => _TB;
            [CompilerGenerated]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set => _TB = value;
        }

        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get => _TextAlign;
            set
            {
                _TextAlign = value;
                if (TB != null)
                {
                    TB.TextAlign = value;
                }
            }
        }

        [Category("Options")]
        public int MaxLength
        {
            get => _MaxLength;
            set
            {
                _MaxLength = value;
                if (TB != null)
                {
                    TB.MaxLength = value;
                }
            }
        }

        [Category("Options")]
        public bool ReadOnly
        {
            get => _ReadOnly;
            set
            {
                _ReadOnly = value;
                if (TB != null)
                {
                    TB.ReadOnly = value;
                }
            }
        }

        [Category("Options")]
        public bool UseSystemPasswordChar
        {
            get => _UseSystemPasswordChar;
            set
            {
                _UseSystemPasswordChar = value;
                if (TB != null)
                {
                    TB.UseSystemPasswordChar = value;
                }
            }
        }

        [Category("Options")]
        public bool Multiline
        {
            get => _Multiline;
            set
            {
                _Multiline = value;
                checked
                {
                    if (TB == null) return;
                    TB.Multiline = value;
                    if (value)
                    {
                        TB.Height = Height - 11;
                    }
                    else
                    {
                        Height = TB.Height + 11;
                    }
                }
            }
        }

        [Category("Options")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (TB != null)
                {
                    TB.Text = value;
                }
            }
        }

        [Category("Options")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                checked
                {
                    if (TB == null) return;
                    TB.Font = value;
                    TB.Location = new Point(3, 5);
                    TB.Width = Width - 6;
                    if (!_Multiline)
                    {
                        Height = TB.Height + 11;
                    }
                }
            }
        }


        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            BackColor = Color.FromArgb(240, 240, 240);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            TB.KeyPress += TextBox_KeyPress;
            if (!Controls.Contains(TB))
            {
                Controls.Add(TB);
            }
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = TB.Text;
        }

        protected override void OnResize(EventArgs e)
        {
            TB.Location = new Point(5, 5);
            checked
            {
                TB.Width = Width - 10;
                var multiline = _Multiline;
                if (multiline)
                {
                    TB.Height = Height - 11;
                }
                else
                {
                    Height = TB.Height + 11;
                }

                base.OnResize(e);
            }
        }

        public override Color ForeColor
        {
            get => _TextColor;
            set => _TextColor = value;
        }

        public enum _Num
        {
            TextNum,
            NumberOnly,
            NumberDot
        }

        private _Num StyleType;

        public _Num Style
        {
            get => StyleType;
            set
            {
                StyleType = value;
                Invalidate();
            }
        }



        public void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (StyleType)
            {
                case _Num.TextNum:

                    e.Handled = false;

                    break;
                case _Num.NumberOnly:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&&       (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                    }

                    break;
                case _Num.NumberDot:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }

                    break;
            }


        }

        public TFiveTextBox()
        {

            _TextAlign = HorizontalAlignment.Left;
            _MaxLength = 32767;
            _BaseColor = Color.FromArgb(240, 240, 240);
            _TextColor = Color.FromArgb(0, 100, 255);

            SetStyle(
                ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(0, 100, 255);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TB = new TextBox
            {
                Text = Text,
                BackColor = _BaseColor,
                ForeColor = _TextColor,
                MaxLength = _MaxLength,
                Multiline = _Multiline,
                ReadOnly = _ReadOnly,
                UseSystemPasswordChar = _UseSystemPasswordChar,
                BorderStyle = BorderStyle.None
            };
            MinimumSize = new Size(0, 31);
            Font = new Font("Segoe UI", 11);
            TB.Location = new Point(5, 5);
            checked
            {
                TB.Width = Width - 10;
                TB.Cursor = Cursors.IBeam;
                var multiline = _Multiline;
                if (multiline)
                {
                    TB.Height = Height - 11;
                }
                else
                {
                    Height = TB.Height + 11;
                }

                TB.TextChanged += OnBaseTextChanged;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var b = new Bitmap(Width, Height);
            var G = Graphics.FromImage(b);

            checked
            {
                W = Width - 1;
                H = Height - 1;
                var g = G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(BackColor);
                TB.BackColor = _BaseColor;
                TB.ForeColor = _TextColor;
                g.FillRectangle(new SolidBrush(Color.DodgerBlue), 0, 0, Width, Height);
                g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), 1, 1, W - 1, H - 1);
                base.OnPaint(e);
                G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(b, 0, 0);
                b.Dispose();
            }
        }

        private int W;

        private int H;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [AccessedThroughProperty("TB")]
        private TextBox _TB;

        private HorizontalAlignment _TextAlign;

        private int _MaxLength;

        private bool _ReadOnly;

        private bool _UseSystemPasswordChar;

        private bool _Multiline;

        private readonly Color _BaseColor;

        private Color _TextColor;

    }
}