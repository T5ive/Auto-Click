using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveNotificationNumber : Control
    {
        #region Variables

        private int _Value;
        private int _Maximum = 99;

        #endregion
        #region Properties

        public int Value
        {
            get
            {
                if (_Value == 0)
                {
                    return 0;
                }
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _Maximum;
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }



        #endregion

        public TFiveNotificationNumber()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            Text = null;
            DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 20;
            Width = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var _G = e.Graphics;
            var myString = _Value.ToString();
            _G.Clear(Color.FromArgb(240, 240, 240));
            _G.SmoothingMode = SmoothingMode.AntiAlias;
            var LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(18, 20)), Color.DodgerBlue, Color.DodgerBlue, 90f);

            // Fills the body with LGB gradient
            _G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(18, 18)));
            // Draw border
            _G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), new Rectangle(new Point(0, 0), new Size(18, 18)));
            _G.DrawString(myString, new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 253)), new Rectangle(0, 0, Width - 2, Height), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            e.Dispose();
        }

    }
}