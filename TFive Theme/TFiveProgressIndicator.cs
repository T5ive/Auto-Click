using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveProgressIndicator : Control
    {

        #region Variables

        private readonly SolidBrush BaseColor = new SolidBrush(Color.FromArgb(220, 230, 250));
        private readonly SolidBrush AnimationColor = new SolidBrush(Color.DodgerBlue);

        private readonly Timer AnimationSpeedTimer = new Timer();
        private PointF[] FloatPoint;
        private BufferedGraphics BuffGraphics;
        private int IndicatorIndex;
        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        #endregion
        #region Custom Properties



        public int AnimationSpeed
        {
            get => AnimationSpeedTimer.Interval;
            set => AnimationSpeedTimer.Interval = value;
        }

        #endregion
        #region EventArgs

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
            UpdateGraphics();
            SetPoints();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            AnimationSpeedTimer.Enabled = Enabled;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationSpeedTimer.Tick += AnimationSpeed_Tick;
            AnimationSpeedTimer.Start();
        }

        private void AnimationSpeed_Tick(object sender, EventArgs e)
        {
            if (IndicatorIndex.Equals(0))
            {
                IndicatorIndex = FloatPoint.Length - 1;
            }
            else
            {
                IndicatorIndex -= 1;
            }
            Invalidate(false);
        }

        #endregion

        public TFiveProgressIndicator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            Size = new Size(80, 80);
            Text = string.Empty;
            MinimumSize = new Size(80, 80);
            SetPoints();
            AnimationSpeedTimer.Interval = 100;
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private void SetStandardSize()
        {
            var _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        private void SetPoints()
        {
            var stack = new Stack<PointF>();
            var startingFloatPoint = new PointF(Width / 2f, Height / 2f);
            for (var i = 0f; i < 360f; i += 45f)
            {
                SetValue(startingFloatPoint, (int)Math.Round(Width / 2.0 - 15.0), i);
                var endPoint = EndPoint;
                endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
                stack.Push(endPoint);
            }
            FloatPoint = stack.ToArray();
        }

        private void UpdateGraphics()
        {
            if (Width > 0 && Height > 0)
            {
                var size2 = new Size(Width + 1, Height + 1);
                GraphicsContext.MaximumBuffer = size2;
                BuffGraphics = GraphicsContext.Allocate(CreateGraphics(), ClientRectangle);
                BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BuffGraphics.Graphics.Clear(BackColor);
            var num2 = FloatPoint.Length - 1;
            for (var i = 0; i <= num2; i++)
            {
                if (IndicatorIndex == i)
                {
                    BuffGraphics.Graphics.FillEllipse(AnimationColor, FloatPoint[i].X, FloatPoint[i].Y, 15f, 15f);
                }
                else
                {
                    BuffGraphics.Graphics.FillEllipse(BaseColor, FloatPoint[i].X, FloatPoint[i].Y, 15f, 15f);
                }
            }
            BuffGraphics.Render(e.Graphics);
        }


        private double Rise;
        private double Run;
        private PointF _StartingFloatPoint;

        private X AssignValues<X>(ref X Run, X Length)
        {
            Run = Length;
            return Length;
        }

        private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
        {
            var CircleRadian = Math.PI * Angle / 180.0;

            _StartingFloatPoint = StartingFloatPoint;
            Rise = AssignValues(ref Run, Length);
            Rise = Math.Sin(CircleRadian) * Rise;
            Run = Math.Cos(CircleRadian) * Run;
        }

        private PointF EndPoint
        {
            get
            {
                var LocationX = Convert.ToSingle(_StartingFloatPoint.Y + Rise);
                var LocationY = Convert.ToSingle(_StartingFloatPoint.X + Run);

                return new PointF(LocationY, LocationX);
            }
        }
    }
}