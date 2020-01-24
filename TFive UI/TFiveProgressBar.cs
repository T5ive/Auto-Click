using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public class TFiveProgressBar : Control
    {

        #region  Properties 
        private double _Maximum = 100;
        public double Maximum
        {
            get => _Maximum;
            set
            {
                _Maximum = value;
                Value = _Current / value * 100;
                Invalidate();
            }
        }
        private double _Current;
        public double Current
        {
            get => _Current;
            set
            {
                _Current = value;
                Value = value / _Maximum * 100;
                Invalidate();
            }
        }
        private int _Progress;
        public double Value
        {
            get => _Progress;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 100)
                {
                    value = 100;
                }
                _Progress = Convert.ToInt32(value);
                _Current = value * 0.01 * _Maximum;
                if (Width > 0)
                {
                    UpdateProgress();
                }
                Invalidate();
            }
        }

        private Color C3 = Color.FromArgb(220, 230, 250); //Dark Color
        private Color C2 = Color.DodgerBlue; //Light color
        public Color Color1
        {
            get => C2;
            set
            {
                C2 = value;
                UpdateColors();
                Invalidate();
            }
        }

        public Color Color2
        {
            get => C3;
            set
            {
                C3 = value;
                UpdateColors();
                Invalidate();
            }
        }

        #endregion

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        private Graphics G;
        private Bitmap B;
        private Rectangle R1;
        private Rectangle R2;
        private ColorBlend X;
        private Color C1;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private LinearGradientBrush B1;
        private LinearGradientBrush B2;
        private SolidBrush B3;
        public TFiveProgressBar()
        {

            C1 = Color.FromArgb(240, 240, 240); //Background
            P1 = new Pen(Color.FromArgb(70, Color.White), 2F);
            P2 = new Pen(C2);
            P3 = new Pen(Color.DodgerBlue); //Highlight
            B3 = new SolidBrush(Color.FromArgb(100, Color.White));
            X = new ColorBlend(4) {Colors = new[] {C2, C3, C3, C2}, Positions = new[] {0.0F, 0.1F, 0.9F, 1.0F}};
            R2 = new Rectangle(2, 2, 2, 2);
            B2 = new LinearGradientBrush(R2, Color.Transparent, Color.Transparent, 180.0F) {InterpolationColors = X};

        }

        public void UpdateColors()
        {
            P2.Color = C2;
            X.Colors = new Color[] { C2, C3, C3, C2 };
            B2.InterpolationColors = X;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            R1 = new Rectangle(0, 1, Width, 4);
            B1 = new LinearGradientBrush(R1, Color.FromArgb(24, Color.Black), Color.Transparent, 90.0F);
            UpdateProgress();
            Invalidate();
            base.OnSizeChanged(e);
        }

        public void UpdateProgress()
        {
            if (_Progress == 0)
            {
                return;
            }
            R2 = new Rectangle(2, 2, Convert.ToInt32((Width - 4) * (_Progress * 0.01)), Height - 4);
            B2 = new LinearGradientBrush(R2, Color.Transparent, Color.Transparent, 180.0F) {InterpolationColors = X};
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C1);

            G.FillRectangle(B1, R1);

            if (_Progress > 0)
            {
                G.FillRectangle(B2, R2);

                G.FillRectangle(B3, 2, 3, R2.Width, 4);
                G.DrawRectangle(P1, 4, 4, R2.Width - 4, Height - 8);

                G.DrawRectangle(P2, 2, 2, R2.Width - 1, Height - 5);
            }

            G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }
}