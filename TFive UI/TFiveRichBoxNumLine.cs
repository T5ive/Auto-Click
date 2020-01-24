using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
    public partial class TFiveRichBoxNumLine : UserControl
    {
        public TFiveRichBoxNumLine()
        {
            //InitializeComponent();
            //Strip = new TFiveLineNumber(richTextBox1);
            //Controls.Add(Strip);
            //BorderStyle = BorderStyle.None;
            //base.BackColor = richTextBox1.BackColor;
        }


        private TFiveLineNumber Strip { get; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.DrawRectangle(new Pen(Color.DodgerBlue), new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
}
