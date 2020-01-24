using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TFive_Class
{
    public sealed class TFiveInputBox : Form
    {
        

        private const int CsDropshadow = 0x00020000;
        private Label lblMessage;
        private TextBox txtInput;
        private string _txtInput;
        private bool txtPaintInvalidated;
        private string btnOK = @"OK";
        private string btnCancel = @"Cancel";
        private TFiveInputBox()
        {
            
            var pl = new Panel { Dock = DockStyle.Fill };

            var flp = new FlowLayoutPanel { Dock = DockStyle.Fill };
            flp.MouseDown += _MouseDown;
            flp.MouseMove += _MouseMove;
            flp.MouseUp += _MouseUp;



            lblMessage = new Label { Font = new Font("Segoe UI", 10), ForeColor = Color.FromArgb(30, 144, 255), AutoSize = true };
            lblMessage.MouseDown += _MouseDown;
            lblMessage.MouseMove += _MouseMove;
            lblMessage.MouseUp += _MouseUp;


            var txtPl = new Panel
            {
                BorderStyle = BorderStyle.None,
                Width = 360,
                Height = 28,
                Padding = new Padding(5),
                BackColor = Color.FromArgb(240, 240, 240),
                Margin = new Padding(0, 15, 0, 0)
            };
            txtPl.Paint += txtPl_Paint;

            txtInput = new TextBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(0, 100, 255)
                
            };
            txtInput.KeyDown += txtInput_KeyDown;
            txtInput.BackColor = Color.FromArgb(240, 240, 240);
            txtInput.Multiline = true;
            txtPl.Controls.Add(txtInput);

            var flpButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 35
            };

            flpButtons.MouseDown += _MouseDown;
            flpButtons.MouseMove += _MouseMove;
            flpButtons.MouseUp += _MouseUp;

            var btnCancel = new Button
            {
                Text = this.btnCancel,
                ForeColor = Color.FromArgb(30, 144, 255),
                Font = new Font("Segoe UI", 8),
                Padding = new Padding(3),
                FlatStyle = FlatStyle.Flat,
                Height = 30
            };
            btnCancel.Click += btnCancel_Click;

            var btnOK = new Button
            {
                Text = this.btnOK,
                ForeColor = Color.FromArgb(30, 144, 255),
                Font = new Font("Segoe UI", 8),
                Padding = new Padding(3),
                FlatStyle = FlatStyle.Flat,
                Height = 30
            };
            btnOK.Click += btnOK_Click;

            flpButtons.Controls.Add(btnCancel);
            flpButtons.Controls.Add(btnOK);

            flp.Controls.Add(lblMessage);
            flp.SetFlowBreak(lblMessage, true);
            flp.Controls.Add(txtPl);
            flp.SetFlowBreak(txtPl, true);
            flp.Controls.Add(flpButtons);
            pl.Controls.Add(flp);

            Controls.Add(pl);
            Controls.Add(flpButtons);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(240, 240, 240);
            StartPosition = FormStartPosition.CenterScreen;
            Padding = new Padding(20);
            Width = 400;
            Height = 200;

            InitializeComponent();
            MouseDown += _MouseDown;
            MouseMove += _MouseMove;
            MouseUp += _MouseUp;

            
        }

        void _MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = new Point(e.X, e.Y);
        }

        void _MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
            {
                return;
            }
            var location = new Point(
                Left + e.X - downPoint.X,
                Top + e.Y - downPoint.Y);
            Location = location;
        }

        void _MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = Point.Empty;
        }

        public Point downPoint = Point.Empty;

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = (TextBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                _txtInput = txt.Text;
                Dispose();
            }
            else
            {
                if (txt.Text.Length > 60)
                {
                    txt.Parent.Height = 80;

                    if (!txtPaintInvalidated)
                    {
                        txt.Parent.Invalidate();
                        txtPaintInvalidated = true;
                    }
                }

                if (txt.Text.Length < 60)
                {
                    txt.Parent.Height = 28;

                    if (txtPaintInvalidated)
                    {
                        txt.Parent.Invalidate();
                        txtPaintInvalidated = false;
                    }
                }
            }
        }

        void txtPl_Paint(object sender, PaintEventArgs e)
        {
            var pl = (Panel)sender;
            base.OnPaint(e);

            var g = e.Graphics;
            var rect = new Rectangle(new Point(0, 0), new Size(pl.Width - 1, pl.Height - 1));
            var pen = new Pen(Color.FromArgb(30, 144, 255)) { Width = 3 };
            g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), rect);
            g.DrawRectangle(pen, rect);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            _txtInput = txtInput.Text;
            Dispose();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        /// <summary>
        /// Example: string input = TFiveInputBox.Show("Please enter your name");
        /// </summary>
        /// <param name="message"> Title</param>
        /// <returns></returns>
        public static string Show(string message)
        {
            using (var box = new TFiveInputBox { lblMessage = { Text = message } })
            {
                box.ShowDialog();

                return box._txtInput;
            }
        }
        public static string Show(string message, int maxLength)
        {
            using (var box = new TFiveInputBox { lblMessage = { Text = message }, txtInput = { MaxLength = maxLength } })
            {
                box.ShowDialog();

                return box._txtInput;
            }
        }
        public string Show(string message, string OK)
        {
            btnOK = OK;
            using (var box = new TFiveInputBox { lblMessage = { Text = message } })
            {
                box.ShowDialog();

                return box._txtInput;
            }
        }
        public string Show(string message, string OK, string Cancel)
        {
            btnOK = OK;
            btnCancel = Cancel;
            using (var box = new TFiveInputBox { lblMessage = { Text = message } })
            {
                box.ShowDialog();

                return box._txtInput;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            var rect = new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1));
            var pen = new Pen(Color.FromArgb(0, 151, 251));

            g.DrawRectangle(pen, rect);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

         //   ClientSize = new Size(284, 261);
            ControlBox = false;
            Name = "TFiveInputBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            ResumeLayout(false);

        }
        
    }
}
