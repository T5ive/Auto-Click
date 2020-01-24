using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveControlBox : Control
    {

        #region  Enums

        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        #endregion
        #region  MouseStates
        MouseState State = MouseState.None;
        int X;
        Rectangle CloseBtn = new Rectangle(3, 2, 17, 17);
        Rectangle MinBtn = new Rectangle(23, 2, 17, 17);
        Rectangle MaxBtn = new Rectangle(43, 2, 17, 17);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (X > 3 && X < 20)
            {
                FindForm()?.Close();
            }
            else if (X > 23 && X < 40)
            {
                FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 43 && X < 60)
            {
                if (_EnableMaximize)
                {
                    if (FindForm().WindowState == FormWindowState.Maximized)
                    {
                        FindForm().WindowState = FormWindowState.Minimized;
                        FindForm().WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        FindForm().WindowState = FormWindowState.Minimized;
                        FindForm().WindowState = FormWindowState.Maximized;
                    }
                }
            }
            State = MouseState.Over;
            Invalidate();
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
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }
        #endregion
        #region  Properties

        bool _EnableMaximize;
        public bool EnableMaximize
        {
            get => _EnableMaximize;
            set
            {
                _EnableMaximize = value;
                Size = _EnableMaximize ? new Size(64, 22) : new Size(44, 22);
                Invalidate();
            }
        }

        #endregion

        public TFiveControlBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Font = new Font("Marlett", 7);
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = _EnableMaximize ? new Size(64, 22) : new Size(44, 22);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // Auto-decide control location on the theme container
            Location = new Point(5, 13);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            base.OnPaint(e);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            var LGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(99, 132, 242), Color.FromArgb(99, 132, 242), 90);
            G.FillEllipse(LGBClose, CloseBtn);
            G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), CloseBtn);
            G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle((int)6.5, 8, 0, 0));

            var LGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(240, 240, 250), Color.FromArgb(240, 240, 250), 90);
            G.FillEllipse(LGBMinimize, MinBtn);
            G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), MinBtn);
            G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(26, (int)4.4, 0, 0));

            if (_EnableMaximize)
            {
                var LGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(240, 240, 250), Color.FromArgb(240, 240, 250), 90);
                G.FillEllipse(LGBMaximize, MaxBtn);
                G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), MaxBtn);
                G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(46, 7, 0, 0));
            }

            switch (State)
            {
                case MouseState.None:
                    var xLGBClose_1 = new LinearGradientBrush(CloseBtn, Color.FromArgb(99, 132, 242), Color.FromArgb(99, 132, 242), 90);
                    G.FillEllipse(xLGBClose_1, CloseBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), CloseBtn);
                    G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle((int)6.5, 8, 0, 0));

                    var xLGBMinimize_1 = new LinearGradientBrush(MinBtn, Color.FromArgb(240, 240, 250), Color.FromArgb(240, 240, 250), 90);
                    G.FillEllipse(xLGBMinimize_1, MinBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), MinBtn);
                    G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(26, (int)4.4, 0, 0));

                    if (_EnableMaximize)
                    {
                        var xLGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(240, 240, 250), Color.FromArgb(240, 240, 250), 90);
                        G.FillEllipse(xLGBMaximize, MaxBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), MaxBtn);
                        G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(46, 7, 0, 0));
                    }
                    break;
                case MouseState.Over:
                    if (X > 3 && X < 20)
                    {
                        var xLGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(248, 152, 124), Color.FromArgb(231, 92, 45), 90);
                        G.FillEllipse(xLGBClose, CloseBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), CloseBtn);
                        G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle((int)6.5, 8, 0, 0));
                    }
                    else if (X > 23 && X < 40)
                    {
                        var xLGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(220, 230, 250), Color.FromArgb(220, 230, 250), 90);
                        G.FillEllipse(xLGBMinimize, MinBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), MinBtn);
                        G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(26, (int)4.4, 0, 0));
                    }
                    else if (X > 43 && X < 60)
                    {
                        if (_EnableMaximize)
                        {
                            var xLGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(220, 230, 250), Color.FromArgb(220, 230, 250), 90);
                            G.FillEllipse(xLGBMaximize, MaxBtn);
                            G.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), MaxBtn);
                            G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(46, 7, 0, 0));
                        }
                    }
                    break;
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
}