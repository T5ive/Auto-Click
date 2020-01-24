using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
   public class TFiveCircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using (var obj = new GraphicsPath())
            {
                obj.AddEllipse(0, 0, Width - 1, Height - 1);
                Region = new Region(obj);
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pe.Graphics.DrawEllipse(new Pen(new SolidBrush(BackColor), 1), 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
