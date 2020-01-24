using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TFive
{
    public class RectDrawing
    {

        public static void DrawSelection(Graphics G, xColorTable ColorTable, Rectangle Rect)
        {
            var FillRect = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

            var TopRect = FillRect;
            TopRect.Height -= Convert.ToInt32(TopRect.Height / 2);
            var BottomRect = new Rectangle(TopRect.X, TopRect.Bottom, TopRect.Width, FillRect.Height - TopRect.Height);

            // Top gradient
            using (var LGB = new LinearGradientBrush(TopRect, ColorTable.SelectionTopGradient, ColorTable.SelectionMidGradient, LinearGradientMode.Vertical))
            {
                G.FillRectangle(LGB, TopRect);
            }


            // Bottom
            using (var B1 = new SolidBrush(ColorTable.SelectionBottomGradient))
            {
                G.FillRectangle(B1, BottomRect);
            }


            // Border
            using (var P1 = new Pen(ColorTable.SelectionBorder))
            {
                DrawRoundedRectangle(G, P1, Convert.ToSingle(Rect.X), Convert.ToSingle(Rect.Y), Convert.ToSingle(Rect.Width), Convert.ToSingle(Rect.Height), 2);
            }

        }

        public static void DrawRoundedRectangle(Graphics G, Pen P, float X, float Y, float W, float H, float Rad)
        {

            using (var gp = new GraphicsPath())
            {
                gp.AddLine(X + Rad, Y, X + W - Rad * 2, Y);
                gp.AddArc(X + W - Rad * 2, Y, Rad * 2, Rad * 2, 270, 90);
                gp.AddLine(X + W, Y + Rad, X + W, Y + H - Rad * 2);
                gp.AddArc(X + W - Rad * 2, Y + H - Rad * 2, Rad * 2, Rad * 2, 0, 90);
                gp.AddLine(X + W - Rad * 2, Y + H, X + Rad, Y + H);
                gp.AddArc(X, Y + H - Rad * 2, Rad * 2, Rad * 2, 90, 90);
                gp.AddLine(X, Y + H - Rad * 2, X, Y + Rad);
                gp.AddArc(X, Y, Rad * 2, Rad * 2, 180, 90);
                gp.CloseFigure();

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.DrawPath(P, gp);
                G.SmoothingMode = SmoothingMode.Default;
            }

        }
    }
}