using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TFive_Auto_Click.Properties;

namespace TFive_Auto_Click
{
    public partial class FrmColorInfo : Form
    {
        public FrmColorInfo()
        {
            InitializeComponent();
            //picTarget.Image = TFive_UI.Properties.Resources.bmpFind;
            //pic_click.Image = TFive_UI.Properties.Resources.bmpFind;
            var cv = new CursorConverter();
            CurTarget = (Cursor)cv.ConvertFrom(TFive_UI.Properties.Resources.curTarget);
        }

        #region FormLoad/Save

        private void GetColor_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Location == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationColor;
            }

            bitmapFind = TFive_UI.Properties.Resources.bmpFind;
            bitmapFind2 = TFive_UI.Properties.Resources.bmpFinda;
            newCursor = CurTarget;
        }
        private void FrmColorInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LocationColor = Location;
            Settings.Default.Save();
        }

        #endregion


        #region Cusor

        #region Cusor

        private readonly Cursor CurTarget;
        private Bitmap bitmapFind;
        private Bitmap bitmapFind2;
        private Cursor newCursor;
        #endregion

        #region Var

        private const uint GaRoot = 2;
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        #endregion

        #region Dll Import

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        #endregion

        #endregion
   
        #region Control Mouse
        [DllImport("user32.dll")] public static extern short GetAsyncKeyState(Keys vKey);

        private void tm_mouse_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.Up) != 0)
            {
                MouseMove(-1, 0);
            }
            if (GetAsyncKeyState(Keys.Down) != 0)
            {
                MouseMove(1, 0);
            }
            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                MouseMove(0, -1);
            }
            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                MouseMove(0, 1);
            }
        }

        private new void MouseMove(int y, int x)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
        }

        #endregion

        #region Windows Info
        
        readonly FrmMagnify _frmMagnify = new FrmMagnify();
        readonly GetAppName _getApp = new GetAppName();

        #region Get Posision Color
        private void picTarget_MouseDown(object sender, MouseEventArgs e)
        {
            picTarget.Image = bitmapFind2;
            picTarget.Cursor = newCursor;
            _frmMagnify.Show();
            timer1.Start();
            tm_mouse.Start();
        }

        private void picTarget_MouseUp(object sender, MouseEventArgs e)
        {
            picTarget.Cursor = Cursors.Default;
            picTarget.Image = bitmapFind;
            _frmMagnify.Hide();
            timer1.Stop();
            tm_mouse.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetPositionColor();
        }
        private void GetPositionColor()
        {
            try
            {
                var pt = Cursor.Position;
                var wnd = WindowFromPoint(pt.X, pt.Y);
                var mainWnd = GetAncestor(wnd, GaRoot);
                POINT PT;

                PT.X = pt.X;
                PT.Y = pt.Y;
                ScreenToClient(mainWnd, ref PT);
                txt_title.Text = Win32.Win32.GetWindowText(mainWnd);
                GetAppName.APP = txt_title.Text;
                txt_class.Text = Win32.Win32.GetClassName(mainWnd);
                GetAppName.CLASS = txt_class.Text;


                _getApp.AppName();
                var intPtr = GetAppName.appName;
                txt_posiX.Text = PT.X.ToString();
                txt_posiY.Text = PT.Y.ToString();
                txt_color.Text = GetColor.GetColorString(int.Parse(txt_posiX.Text), int.Parse(txt_posiY.Text));
                lb_status.Text = @"Status: "+ GetColor.GetColorFast(intPtr, PT.X, PT.Y, GetColor.StringColor(txt_color.Text), 4);
                
                if (!GetColor.GetColorFast(intPtr, PT.X, PT.Y, GetColor.StringColor(txt_color.Text), 4))
                {
                    ResetValues(false);
                    
                }

                if (txt_title.Text == @"Get Color")
                {
                    ResetValues(true);
                }

                panel_color.BackColor = _frmMagnify.magnifyingGlass1.PixelColor;
                LocationMagnify();
            }
            catch
            {
                // ignored
            }
        }

        private void ResetValues(bool mode)
        {
            txt_posiX.ResetText();
            txt_posiY.ResetText();
            txt_color.ResetText();
            if (mode)
            {
                txt_title.ResetText();
                txt_class.ResetText();
                lb_status.Text = @"Status: False";
            }
        }
       
        #endregion      

        #region Get Posision Click
        
        private void pic_click_MouseDown(object sender, MouseEventArgs e)
        {
            pic_click.Image = bitmapFind2;
            pic_click.Cursor = newCursor;
            _frmMagnify.Show();
            timer2.Start();
            tm_mouse.Start();
        }

        private void pic_click_MouseUp(object sender, MouseEventArgs e)
        {
            pic_click.Cursor = Cursors.Default;
            pic_click.Image = bitmapFind;
            _frmMagnify.Hide();
            timer2.Stop();
            tm_mouse.Stop();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            GetPositionClick();
        }

        private void GetPositionClick()
        {
            try
            {
                var pt = Cursor.Position;
                var wnd = WindowFromPoint(pt.X, pt.Y);
                var mainWnd = GetAncestor(wnd, GaRoot);
                POINT PT;

                PT.X = pt.X;
                PT.Y = pt.Y;
                ScreenToClient(mainWnd, ref PT);
                txt_title.Text = Win32.Win32.GetWindowText(mainWnd);
                GetAppName.APP = txt_title.Text;
                txt_class.Text = Win32.Win32.GetClassName(mainWnd);
                GetAppName.CLASS = txt_class.Text;
                _getApp.AppName();
                txt_clickX.Text = PT.X.ToString();
                txt_clickY.Text = PT.Y.ToString();
                
                LocationMagnify();
            }
            catch
            {
                // ignored
            }
        }

        #endregion



        private void LocationMagnify()
        {

            var pt = Cursor.Position;
            pt.X = Cursor.Position.X;
            pt.Y = Cursor.Position.Y;
            var width = Screen.PrimaryScreen.Bounds.Width;
            var height = Screen.PrimaryScreen.Bounds.Height;
            var locationX = 30;
            var locationY = 30;
            if (pt.X > width - 167)
            {
                locationX -= 30 + 167;
            }
            if (pt.Y > height - 167)
            {
                locationY -= 30 + 167;
            }

            _frmMagnify.Location = new Point(pt.X + locationX, pt.Y + locationY);
        }

        #endregion

        #region Button
        int NumColor;
        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_title.Text) || string.IsNullOrWhiteSpace(txt_clickX.Text) ||
                string.IsNullOrWhiteSpace(txt_clickY.Text))
            {
                MessageBox.Show(@"Please Input Position Click X&Y", @"TFive Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txt_posiX.Text) || !string.IsNullOrWhiteSpace(txt_posiY.Text))
            {
               AddClick();
            }

            if (NumColor > 1)
            {
                Values.ProcessName = "Found " + NumColor + " Point";
                Values.ListColorString = LB_Position.Items.OfType<string>().ToArray();
                Values.Mode = 1;
            }
            else if(NumColor==1)
            {
                Values.ProcessName = "Found 1 Point";
                Values.Mode = 1;
            }
            else
            {
                Values.ProcessName = "Click";
                Values.Mode = 0;
                goto Skip;
            }

            var text = LB_Position.Items.OfType<string>().ToArray();
            var array = text[0].Split(new []
            {
                ","
            }, StringSplitOptions.RemoveEmptyEntries);
            Values.CheckX = int.Parse(array[0]);
            Values.CheckY = int.Parse(array[1]);
            Values.Color = array[2];

        Skip:

            Values.NumListColor = NumColor;
            if (Values.NumListMax < NumColor)
            {
                Values.NumListMax = NumColor;
            }
            Values.ClickX = int.Parse(txt_clickX.Text);
            Values.ClickY = int.Parse(txt_clickY.Text);
            Values.TitleName = txt_title.Text+" | "+txt_class.Text;
            Values.ClickTimes = (int) num_click.Value;
            Values.Delay = int.Parse(txtDelay.Text);
            Values.CloseFrom = true;
            Close();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            AddClick();
        }

        private void AddClick()
        {
            if (string.IsNullOrWhiteSpace(txt_posiX.Text) || string.IsNullOrWhiteSpace(txt_posiY.Text) || string.IsNullOrWhiteSpace(txt_title.Text))
            {
                return;
            }
            var GetItems = txt_posiX.Text + "," + txt_posiY.Text + "," + txt_color.Text;
            LB_Position.Items.Add(GetItems);
            NumColor = LB_Position.Items.Count;
            txt_posiX.ResetText();
            txt_posiY.ResetText();
            txt_color.ResetText();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Values.CloseFrom = false;
            Close();
        }
        #endregion

        private void LB_Position_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show(@"Are you sure to delete " + (LB_Position.SelectedIndex + 1) + @" ? ", @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    LB_Position.Items.Remove(LB_Position.SelectedItem);
            }
        }



    }
}
