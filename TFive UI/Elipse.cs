using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
    public static class Elipse
    {
        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public static void Apply(Form Form, int _Elipse)
        {
            try
            {
                Form.FormBorderStyle = FormBorderStyle.None;
                Form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Form.Width, Form.Height, _Elipse, _Elipse));
            }
            catch (Exception)
            {
                //
            }
        }

        public static void Apply(Control ctrl, int Elipse)
        {
            try
            {
                ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, Elipse, Elipse));
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
