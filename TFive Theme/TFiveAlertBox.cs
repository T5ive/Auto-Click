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
    public class TFiveAlertBox : Control
    {
        public virtual Timer T
        {
            [CompilerGenerated]
            get => _T;
            [CompilerGenerated]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                var value2 = new EventHandler(T_Tick);
                var t = _T;
                if (t != null)
                {
                    t.Tick -= value2;
                }
                _T = value;
                t = _T;
                if (t != null)
                {
                    t.Tick += value2;
                }
            }
        }

        [Category("Options")]
        public _Kind kind
        {
            get => K;
            set => K = value;
        }

        [Category("Options")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                var flag = _Text != null;
                if (flag)
                {
                    _Text = value;
                }
            }
        }

        [Category("Options")]
        public new bool Visible
        {
            get => !base.Visible;
            set => base.Visible = value;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            BackColor = Color.FromArgb(240, 240, 240);
        }

        public void ShowControl(_Kind Kind, string Str, int Interval)
        {
            K = Kind;
            Text = Str;
            Visible = true;
            T = new Timer();
            T.Interval = Interval;
            T.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Visible = false;
            T.Enabled = false;
            T.Dispose();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = TFive.MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = TFive.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = TFive.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = TFive.MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Visible = false;
        }

        public TFiveAlertBox()
        {
            State = TFive.MouseState.None;
            SuccessColor = Color.FromArgb(60, 85, 79);
            SuccessText = Color.FromArgb(35, 169, 110);

            ErrorColor = Color.FromArgb(87, 71, 71);
            ErrorText = Color.FromArgb(254, 142, 122);

            InfoColor = Color.FromArgb(70, 91, 94);
            InfoText = Color.FromArgb(97, 185, 186);

            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(240, 240, 240);
            Size = new Size(576, 42);
            Location = new Point(10, 61);
            Cursor = Cursors.Hand;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TFive.B = new Bitmap(Width, Height);
            TFive.G = Graphics.FromImage(TFive.B);
            checked
            {
                W = Width - 1;
                H = Height - 1;
                var Base = new Rectangle(0, 0, W, H);
                var g = TFive.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(BackColor);
                switch (K)
                {
                    case _Kind.Success:
                    {
                        g.FillRectangle(new SolidBrush(SuccessColor), Base);
                        g.FillEllipse(new SolidBrush(SuccessText), new Rectangle(8, 9, 24, 24));
                        g.FillEllipse(new SolidBrush(SuccessColor), new Rectangle(10, 11, 20, 20));
                        g.DrawString("ü", new Font("Wingdings", 22f), new SolidBrush(SuccessText), new Rectangle(7, 7, W, H), TFive.nearSf);
                        g.DrawString(Text, Font, new SolidBrush(SuccessText), new Rectangle(48, 12, W, H), TFive.nearSf);
                        g.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 30, H - 29, 17, 17));
                        g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(SuccessColor), new Rectangle(W - 28, 16, W, H), TFive.nearSf);
                        var state = State;
                        if (state == TFive.MouseState.Over)
                        {
                            g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 28, 16, W, H), TFive.nearSf);
                        }
                        break;
                    }
                    case _Kind.Error:
                    {
                        g.FillRectangle(new SolidBrush(ErrorColor), Base);
                        g.FillEllipse(new SolidBrush(ErrorText), new Rectangle(8, 9, 24, 24));
                        g.FillEllipse(new SolidBrush(ErrorColor), new Rectangle(10, 11, 20, 20));
                        g.DrawString("r", new Font("Marlett", 16f), new SolidBrush(ErrorText), new Rectangle(6, 11, W, H), TFive.nearSf);
                        g.DrawString(Text, Font, new SolidBrush(ErrorText), new Rectangle(48, 12, W, H), TFive.nearSf);
                        g.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 32, H - 29, 17, 17));
                        g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(ErrorColor), new Rectangle(W - 30, 17, W, H), TFive.nearSf);
                        var state2 = State;
                        if (state2 == TFive.MouseState.Over)
                        {
                            g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 30, 15, W, H), TFive.nearSf);
                        }
                        break;
                    }
                    case _Kind.Info:
                    {
                        g.FillRectangle(new SolidBrush(InfoColor), Base);
                        g.FillEllipse(new SolidBrush(InfoText), new Rectangle(8, 9, 24, 24));
                        g.FillEllipse(new SolidBrush(InfoColor), new Rectangle(10, 11, 20, 20));
                        g.DrawString("¡", new Font("Segoe UI", 20f, FontStyle.Bold), new SolidBrush(InfoText), new Rectangle(12, -4, W, H), TFive.nearSf);
                        g.DrawString(Text, Font, new SolidBrush(InfoText), new Rectangle(48, 12, W, H), TFive.nearSf);
                        g.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 32, H - 29, 17, 17));
                        g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(InfoColor), new Rectangle(W - 30, 17, W, H), TFive.nearSf);
                        var state3 = State;
                        if (state3 == TFive.MouseState.Over)
                        {
                            g.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 30, 17, W, H), TFive.nearSf);
                        }
                        break;
                    }
                }
                base.OnPaint(e);
                TFive.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(TFive.B, 0, 0);
                TFive.B.Dispose();
            }
        }

        /// How to use: DorAAlertBox.ShowControl(Kind, String, Interval)
        /// EX : DorAAlertBox.ShowControl(DorAAlertBox._Kind.Success, "Nince", 2000)
        private int W;

        /// How to use: DorAAlertBox.ShowControl(Kind, String, Interval)
        /// EX : DorAAlertBox.ShowControl(DorAAlertBox._Kind.Success, "Nince", 2000)
        private int H;

        private _Kind K;

        private string _Text;

        private TFive.MouseState State;

        private int X;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [AccessedThroughProperty("T")]
        private Timer _T;

        private readonly Color SuccessColor;

        private readonly Color SuccessText;

        private readonly Color ErrorColor;

        private readonly Color ErrorText;

        private readonly Color InfoColor;

        private readonly Color InfoText;

        [Flags]
        public enum _Kind
        {
            Success = 0,
            Error = 1,
            Info = 2
        }
    }
}