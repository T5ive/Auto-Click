using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public class ControlRenderer : ToolStripProfessionalRenderer
    {

        public ControlRenderer() : this(new TFiveColorTable())
        {

        }

        public ControlRenderer(ColorTable ColorTable)
        {
            this.ColorTable = ColorTable;
        }

        private ColorTable _ColorTable;
        public new ColorTable ColorTable
        {
            get => _ColorTable ?? (_ColorTable = new TFiveColorTable());
            set => _ColorTable = value;
        }

        readonly int _Curv = 1;
        readonly int _Curv2 = 1;
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);

            // Menu strip bar gradient
            using (var LGB = new LinearGradientBrush(e.AffectedBounds, ColorTable.BackgroundTopGradient, ColorTable.BackgroundBottomGradient, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(LGB, e.AffectedBounds);
            }

        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.Parent != null) return;
            // Draw border around the menu drop-down
            var Rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using (var P1 = new Pen(ColorTable.CommonColorTable.DropdownBorder))
            {
                e.Graphics.DrawRectangle(P1, Rect);
            }


            // Fill the gap between menu drop-down and owner item
            using (var B1 = new SolidBrush(ColorTable.DroppedDownItemBackground))
            {
                e.Graphics.FillRectangle(B1, e.ConnectedArea);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Enabled) return;
            if (e.Item.Selected)
            {
                if (!e.Item.IsOnDropDown)
                {
                    var SelRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
                    RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, SelRect);
                }
                else
                {
                    var SelRect = new Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1);
                    RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, SelRect);
                }
            }

            if (((ToolStripMenuItem)e.Item).DropDown.Visible && !e.Item.IsOnDropDown)
            {
                var BorderRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height);
                // Fill the background
                var BackgroundRect = new Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2);
                using (var B1 = new SolidBrush(ColorTable.DroppedDownItemBackground))
                {
                    e.Graphics.FillRectangle(B1, BackgroundRect);
                }


                // Draw border
                using (var P1 = new Pen(ColorTable.CommonColorTable.DropdownBorder))
                {
                    RectDrawing.DrawRoundedRectangle(e.Graphics, P1, Convert.ToSingle(BorderRect.X), Convert.ToSingle(BorderRect.Y), Convert.ToSingle(BorderRect.Width), Convert.ToSingle(BorderRect.Height), _Curv);
                }

            }
            e.Item.ForeColor = ColorTable.CommonColorTable.TextColor;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ColorTable.CommonColorTable.TextColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);

            var rect = new Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3);
            var c = default(Color);

            c = e.Item.Selected ? ColorTable.CommonColorTable.CheckedSelectedBackground : ColorTable.CommonColorTable.CheckedBackground;

            using (var b = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(b, rect);
            }


            using (var p = new Pen(ColorTable.CommonColorTable.SelectionBorder))
            {
                e.Graphics.DrawRectangle(p, rect);
            }


            e.Graphics.DrawString("ü", new Font("Wingdings", 13, FontStyle.Regular), Brushes.White, new Point(4, 2));
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
            var PT1 = 28;
            var PT2 = Convert.ToInt32(e.Item.Width);
            var Y = 3;
            using (var P1 = new Pen(ColorTable.Separator))
            {
                e.Graphics.DrawLine(P1, PT1, Y, PT2, Y);
            }

        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            var BackgroundRect = new Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1);
            using (var LGB = new LinearGradientBrush(BackgroundRect,
                ColorTable.DropdownTopGradient,
                ColorTable.DropdownBottomGradient,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(LGB, BackgroundRect);
            }


            using (var B1 = new SolidBrush(ColorTable.ImageMargin))
            {
                e.Graphics.FillRectangle(B1, e.AffectedBounds);
            }

        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
            var @checked = Convert.ToBoolean(((ToolStripButton)e.Item).Checked);
            var drawBorder = false;

            if (@checked)
            {
                drawBorder = true;

                if (e.Item.Selected && !e.Item.Pressed)
                {
                    using (var b = new SolidBrush(ColorTable.CommonColorTable.CheckedSelectedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                }
                else
                {
                    using (var b = new SolidBrush(ColorTable.CommonColorTable.CheckedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                }

            }
            else
            {

                if (e.Item.Pressed)
                {
                    drawBorder = true;
                    using (var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                }
                else if (e.Item.Selected)
                {
                    drawBorder = true;
                    RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, rect);
                }

            }

            if (drawBorder)
            {
                using (var p = new Pen(ColorTable.CommonColorTable.SelectionBorder))
                {
                    e.Graphics.DrawRectangle(p, rect);
                }

            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
            var drawBorder = false;

            if (e.Item.Pressed)
            {
                drawBorder = true;
                using (var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

            }
            else if (e.Item.Selected)
            {
                drawBorder = true;
                RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, rect);
            }

            if (drawBorder)
            {
                using (var p = new Pen(ColorTable.CommonColorTable.SelectionBorder))
                {
                    e.Graphics.DrawRectangle(p, rect);
                }

            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderSplitButtonBackground(e);
            var drawBorder = false;
            var drawSeparator = true;
            var item = (ToolStripSplitButton)e.Item;
            checked
            {
                var btnRect = new Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1);
                var borderRect = new Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1);
                var flag = item.DropDownButtonPressed;
                if (flag)
                {
                    drawBorder = true;
                    drawSeparator = false;
                    var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground);
                    try
                    {
                        e.Graphics.FillRectangle(b, borderRect);
                    }
                    finally
                    {
                        b.Dispose();
                    }
                }
                else
                {
                    flag = item.DropDownButtonSelected;
                    if (flag)
                    {
                        drawBorder = true;
                        RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, borderRect);
                    }
                }
                flag = item.ButtonPressed;
                if (flag)
                {
                    var b2 = new SolidBrush(ColorTable.CommonColorTable.PressedBackground);
                    try
                    {
                        e.Graphics.FillRectangle(b2, btnRect);
                    }
                    finally
                    {
                        b2.Dispose();
                    }
                }
                flag = drawBorder;
                if (!flag) return;
                var p = new Pen(ColorTable.CommonColorTable.SelectionBorder);
                try
                {
                    e.Graphics.DrawRectangle(p, borderRect);
                    flag = drawSeparator;
                    if (flag)
                    {
                        e.Graphics.DrawRectangle(p, btnRect);
                    }
                }
                finally
                {
                    p.Dispose();
                }
                DrawCustomArrow(e.Graphics, item);
            }
        }

        private void DrawCustomArrow(Graphics g, ToolStripSplitButton item)
        {
            var dropWidth = Convert.ToInt32(item.DropDownButtonBounds.Width - 1);
            var dropHeight = Convert.ToInt32(item.DropDownButtonBounds.Height - 1);
            var triangleWidth = dropWidth / 2.0F + 1;
            var triangleLeft = Convert.ToSingle(item.DropDownButtonBounds.Left + (dropWidth - triangleWidth) / 2.0F);
            var triangleHeight = triangleWidth / 2.0F;
            var triangleTop = Convert.ToSingle(item.DropDownButtonBounds.Top + (dropHeight - triangleHeight) / 2.0F + 1);
            var arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);

            DrawCustomArrow(g, item, Rectangle.Round(arrowRect));
        }

        private void DrawCustomArrow(Graphics g, ToolStripItem item, Rectangle rect)
        {
            var arrowEventArgs = new ToolStripArrowRenderEventArgs(g, item, rect, ColorTable.CommonColorTable.Arrow, ArrowDirection.Down);
            base.OnRenderArrow(arrowEventArgs);
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2);
            var rectEnd = new Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height);

            if (e.Item.Pressed)
            {
                using (var b = new SolidBrush(ColorTable.CommonColorTable.PressedBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

            }
            else if (e.Item.Selected)
            {
                RectDrawing.DrawSelection(e.Graphics, ColorTable.CommonColorTable, rect);
            }
            else
            {
                using (var b = new SolidBrush(ColorTable.CommonColorTable.OverflowBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

            }

            using (var P1 = new Pen(ColorTable.CommonColorTable.Background))
            {
                RectDrawing.DrawRoundedRectangle(e.Graphics, P1, Convert.ToSingle(rectEnd.X), Convert.ToSingle(rectEnd.Y), Convert.ToSingle(rectEnd.Width), Convert.ToSingle(rectEnd.Height), _Curv2);
            }


            // Icon
            var w = Convert.ToInt32(rect.Width - 1);
            var h = Convert.ToInt32(rect.Height - 1);
            var triangleWidth = w / 2.0F + 1;
            var triangleLeft = Convert.ToSingle(rect.Left + (w - triangleWidth) / 2.0F + 3);
            var triangleHeight = triangleWidth / 2.0F;
            var triangleTop = Convert.ToSingle(rect.Top + (h - triangleHeight) / 2.0F + 7);
            var arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);
            DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(arrowRect));

            using (var p = new Pen(ColorTable.CommonColorTable.Arrow))
            {
                e.Graphics.DrawLine(p, triangleLeft + 2, triangleTop - 2, triangleLeft + triangleWidth - 2, triangleTop - 2);
            }

        }
    }
}