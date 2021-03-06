﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveIconInfo : Control
    {
        public TFiveIconInfo()
        {
            ForeColor = Color.DodgerBlue;
            BackColor = Color.FromArgb(240, 240, 240);
            Size = new Size(33, 33);
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillEllipse(new SolidBrush(Color.DodgerBlue), new Rectangle(1, 1, 29, 29));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(240, 240, 240)), new Rectangle(3, 3, 25, 25));

            e.Graphics.DrawString("¡", new Font("Segoe UI", 25, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), new Rectangle(4, -14, Width, 43), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });
        }
    }
}