using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public class TFiveButton : ThemeControl
    {
        public TFiveButton()
        {
            AccentColor = Color.FromArgb(0, 100, 255);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Segoe UI", 11);
        }
        public override void PaintHook()
        {

            var PenColor = Pens.White;
            var border = new Pen(Color.DodgerBlue);


            G.Clear(Color.FromArgb(102, 102, 102));
            checked
            {
                switch (MouseState)
                {
                    case State.MouseNone:
                        DrawGradient(Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), 0, 0, Width, Height, 90f);
                        G.DrawLine(PenColor, 1, 1, Width - 1, 1);
                        AccentColor = Color.FromArgb(0, 100, 255);
                        break;
                    case State.MouseOver:
                        DrawGradient(Color.FromArgb(220, 230, 250), Color.FromArgb(220, 230, 250), 0, 0, Width, Height, 90f);
                        G.DrawLine(PenColor, 1, 1, Width - 1, 1);
                        AccentColor = Color.FromArgb(0, 100, 255);
                        break;
                    case State.MouseDown:
                        DrawGradient(Color.DodgerBlue, Color.DodgerBlue, 0, 0, Width, Height, 90f);
                        G.DrawLine(PenColor, 1, Height - 2, Width - 1, Height - 2);
                        AccentColor = Color.White;
                        break;
                }
                DrawBorders(border, Pens.Transparent, ClientRectangle);
                DrawText(HorizontalAlignment.Center, AccentColor, -1, 0);
            }
        }

        private Color AccentColor;


    }
}