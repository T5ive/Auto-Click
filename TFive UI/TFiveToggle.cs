using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    [DefaultEvent("ToggledChanged")]
    public class TFiveToggle : Control
    {

        #region  Enums

        public enum _Type
        {
            OnOff,
            YesNo,
            IO
        }

        #endregion
        #region  Variables

        public delegate void ToggledChangedEventHandler();
        private ToggledChangedEventHandler ToggledChangedEvent;

        public event ToggledChangedEventHandler ToggledChanged
        {
            add => ToggledChangedEvent = (ToggledChangedEventHandler)Delegate.Combine(ToggledChangedEvent, value);
            remove => ToggledChangedEvent = (ToggledChangedEventHandler)Delegate.Remove(ToggledChangedEvent, value);
        }

        private bool _Toggled;
        private _Type ToggleType;
        private Rectangle Bar;
        private Size cHandle = new Size(15, 20);

        #endregion
        #region  Properties

        public bool Toggled
        {
            get => _Toggled;
            set
            {
                _Toggled = value;
                Invalidate();
                if (ToggledChangedEvent != null)
                    ToggledChangedEvent();
            }
        }

        public _Type Type
        {
            get => ToggleType;
            set
            {
                ToggleType = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs
        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2
        }
        MouseState State = MouseState.None;
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 79;
            Height = 27;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
            Focus();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        #endregion

        public TFiveToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.FromArgb(240, 240, 240));

            var SwitchXLoc = 3;
            var ControlRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            var ControlPath = RoundRectangle.RoundRect(ControlRectangle, 4);

            var BackgroundLGB = default(LinearGradientBrush);
            if (_Toggled)
            {
                SwitchXLoc = 37;
                BackgroundLGB = new LinearGradientBrush(ControlRectangle, Color.DodgerBlue, Color.DodgerBlue, 90.0F);
            }
            else
            {
                SwitchXLoc = 0;
                BackgroundLGB = new LinearGradientBrush(ControlRectangle, Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), 90.0F);
            }

            // Fill inside background gradient
            G.FillPath(BackgroundLGB, ControlPath);

            // Draw string
            switch (ToggleType)
            {
                case _Type.OnOff:
                    if (Toggled)
                    {
                        G.DrawString("ON", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("OFF", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DodgerBlue, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case _Type.YesNo:
                    if (Toggled)
                    {
                        G.DrawString("YES", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("NO", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DodgerBlue, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case _Type.IO:
                    if (Toggled)
                    {
                        G.DrawString("I", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("O", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DodgerBlue, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
            }

            var SwitchRectangle = new Rectangle(SwitchXLoc, 0, Width - 38, Height);
            var SwitchPath = RoundRectangle.RoundRect(SwitchRectangle, 4);
            LinearGradientBrush SwitchButtonLGB;

            SwitchButtonLGB = new LinearGradientBrush(SwitchRectangle, Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), LinearGradientMode.Vertical);
            switch (State)
            {
                case MouseState.None:
                    SwitchButtonLGB = new LinearGradientBrush(SwitchRectangle, Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), LinearGradientMode.Vertical);
                    break;
                case MouseState.Over:
                    SwitchButtonLGB = new LinearGradientBrush(SwitchRectangle, Color.FromArgb(220, 230, 250), Color.FromArgb(220, 230, 250), LinearGradientMode.Vertical);
                    break;
            }


            // Fill switch background gradient
            G.FillPath(SwitchButtonLGB, SwitchPath);

            // Draw borders
            if (_Toggled == true)
            {
                G.DrawPath(new Pen(Color.DodgerBlue), SwitchPath);
                G.DrawPath(new Pen(Color.DodgerBlue), ControlPath);
            }
            else
            {
                G.DrawPath(new Pen(Color.DodgerBlue), SwitchPath);
                G.DrawPath(new Pen(Color.DodgerBlue), ControlPath);
            }
        }
    }
}