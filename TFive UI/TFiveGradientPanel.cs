using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
    public class TFiveGradientPanel : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            var lgb = new LinearGradientBrush(ClientRectangle, ColorTop, ColorBottom, 90F);
            var g = e.Graphics;
            g.FillRectangle(lgb, ClientRectangle);
            base.OnPaint(e);
        }
    }
}
