using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveTheme : ContainerControl
    {

        #region  Enums

        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion
        #region  Variables

        private Rectangle HeaderRect;
        private MouseState State;
        private readonly int MoveHeight;
        private Point MouseP = new Point(0, 0);
        private bool Cap;
        private bool HasShown;

        #endregion
        #region  Properties

        public bool _Sizable = true;
        public bool Sizable
        {
            get => _Sizable;
            set => _Sizable = value;
        }

        public bool _SmartBounds = true;
        public bool SmartBounds
        {
            get => _SmartBounds;
            set => _SmartBounds = value;
        }

        private bool _RoundCorners = true;
        public bool RoundCorners
        {
            get => _RoundCorners;
            set
            {
                _RoundCorners = value;
                Invalidate();
            }
        }

        public bool _IsParentForm;

        private bool IsParentMdi => Parent?.Parent != null;

        private bool _ControlMode;

        private bool ControlMode
        {
            get => _ControlMode;
            set
            {
                _ControlMode = value;
                Invalidate();
            }
        }

        private FormStartPosition _StartPosition;
        public FormStartPosition StartPosition
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                {
                    return ParentForm.StartPosition;
                }

                return _StartPosition;
            }
            set
            {
                _StartPosition = value;

                if (!_IsParentForm || _ControlMode) return;
                if (ParentForm != null) ParentForm.StartPosition = value;
            }
        }

        #endregion
        #region  EventArgs

        protected sealed override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent == null)
            {
                return;
            }
            _IsParentForm = Parent is Form;

            if (!_ControlMode)
            {
                InitializeMessages();

                if (_IsParentForm)
                {
                    //  ParentForm.FormBorderStyle = FormBorderStyle.None;
                    ParentForm.TransparencyKey = Color.Fuchsia;

                    if (!DesignMode)
                    {
                        ParentForm.Shown += FormShown;
                    }
                }
                Parent.BackColor = BackColor;
                Parent.MinimumSize = new Size(261, 65);
            }
        }

        protected sealed override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!_ControlMode)
            {
                HeaderRect = new Rectangle(0, 0, Width - 14, MoveHeight - 7);
            }
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                SetState(MouseState.Down);
            }
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
            {
                if (HeaderRect.Contains(e.Location))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[0]);
                }
                else if (_Sizable && !(Previous == 0))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[Previous]);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
            {
                if (_Sizable && !_ControlMode)
                {
                    InvalidateMouse();
                }
            }
            if (Cap)
            {
                Parent.Location = (Point)(object)(Convert.ToDouble(MousePosition) - Convert.ToDouble(MouseP));
            }
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            if (_border)
            {
                ParentForm.Text = Text;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        private void FormShown(object sender, EventArgs e)
        {
            if (_ControlMode || HasShown)
            {
                return;
            }

            if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
            {
                var SB = Screen.PrimaryScreen.Bounds;
                var CB = ParentForm.Bounds;
                ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
            }
            HasShown = true;
        }

        #endregion
        #region  Mouse & Size

        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        private Point GetIndexPoint;
        private bool B1x;
        private bool B2x;
        private bool B3;
        private bool B4;
        private int GetIndex()
        {
            GetIndexPoint = PointToClient(MousePosition);
            B1x = GetIndexPoint.X < 7;
            B2x = GetIndexPoint.X > Width - 7;
            B3 = GetIndexPoint.Y < 7;
            B4 = GetIndexPoint.Y > Height - 7;

            if (B1x && B3)
            {
                return 4;
            }
            if (B1x && B4)
            {
                return 7;
            }
            if (B2x && B3)
            {
                return 5;
            }
            if (B2x && B4)
            {
                return 8;
            }
            if (B1x)
            {
                return 1;
            }
            if (B2x)
            {
                return 2;
            }
            if (B3)
            {
                return 3;
            }
            if (B4)
            {
                return 6;
            }
            return 0;
        }

        private int Current;
        private int Previous;
        private void InvalidateMouse()
        {
            Current = GetIndex();
            if (Current == Previous)
            {
                return;
            }

            Previous = Current;
            switch (Previous)
            {
                case 0:
                    Cursor = Cursors.Default;
                    break;
                case 6:
                    Cursor = Cursors.SizeNS;
                    break;
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 7:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        private Message[] Messages = new Message[9];
        private void InitializeMessages()
        {
            Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (var I = 1; I <= 8; I++)
            {
                Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        private void CorrectBounds(Rectangle bounds)
        {
            if (Parent.Width > bounds.Width)
            {
                Parent.Width = bounds.Width;
            }
            if (Parent.Height > bounds.Height)
            {
                Parent.Height = bounds.Height;
            }

            var X = Parent.Location.X;
            var Y = Parent.Location.Y;

            if (X < bounds.X)
            {
                X = bounds.X;
            }
            if (Y < bounds.Y)
            {
                Y = bounds.Y;
            }

            var Width = bounds.X + bounds.Width;
            var Height = bounds.Y + bounds.Height;

            if (X + Parent.Width > Width)
            {
                X = Width - Parent.Width;
            }
            if (Y + Parent.Height > Height)
            {
                Y = Height - Parent.Height;
            }

            Parent.Location = new Point(X, Y);
        }

        private bool WM_LMBUTTONDOWN;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (WM_LMBUTTONDOWN && m.Msg == 513)
            {
                WM_LMBUTTONDOWN = false;

                SetState(MouseState.Over);
                if (!_SmartBounds)
                {
                    return;
                }

                if (IsParentMdi)
                {
                    CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
                }
                else
                {
                    CorrectBounds(Screen.FromControl(Parent).WorkingArea);
                }
            }
        }

        #endregion
        bool _border = true;
        public bool Border
        {
            get => _border;
            set
            {
                _border = value;
                Invalidate();
            }
        }

        public TFiveTheme()
        {
            SetStyle((ControlStyles)139270, true);
            BackColor = Color.FromArgb(240, 240, 240);
            Padding = new Padding(20, 56, 20, 16);
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            MoveHeight = 48;
            Font = new Font("Segoe UI", 9);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            G.Clear(Color.FromArgb(240, 240, 255));

            if (_border)
            {
                G.DrawRectangle(new Pen(Color.DodgerBlue), new Rectangle(0, 0, Width - 1, Height - 1));//กรอบนอก
                G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, 36), Color.FromArgb(240, 240, 255), Color.FromArgb(240, 240, 255)), new Rectangle(1, 1, Width - 2, 36));
                G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(240, 240, 255), Color.FromArgb(240, 240, 255)), new Rectangle(1, 36, Width - 2, Height - 46));
                G.DrawRectangle(new Pen(Color.DodgerBlue), new Rectangle(9, 47, Width - 19, Height - 55));//กรอบใน
            }
            else
            {
                G.DrawRectangle(new Pen(Color.DodgerBlue), new Rectangle(0, 0, Width - 1, 1));//กรอบบน
                G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, 36), Color.FromArgb(240, 240, 255), Color.FromArgb(240, 240, 255)), new Rectangle(1, 1, Width - 2, 36));
                G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(240, 240, 255), Color.FromArgb(240, 240, 255)), new Rectangle(1, 36, Width - 2, Height - 46));
            }



            G.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), new Rectangle(10, 48, Width - 20, Height - 56));

            if (_RoundCorners == true)
            {

                // Draw Left upper corner
                G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);

                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, 3, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, 2, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 2, 1, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 3, 1, 1, 1);

                // Draw right upper corner
                G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1);

                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 2, 3, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 2, 2, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 3, 1, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 4, 1, 1, 1);

                // Draw Left bottom corner
                G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1);

                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, Height - 3, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, Height - 4, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 3, Height - 2, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 2, Height - 2, 1, 1);

                // Draw right bottom corner
                G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1);
                G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1);

                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 2, Height - 3, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 2, Height - 4, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 4, Height - 2, 1, 1);
                G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), Width - 3, Height - 2, 1, 1);
            }

            G.DrawString(Text, new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(0, 14, Width - 1, Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
        }
    }
}