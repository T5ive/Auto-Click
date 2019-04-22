using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveTabControl : TabControl
    {

        public TFiveTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Font = new Font("Segoe UI", 11);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            ItemSize = new Size(330, 30);
            Alignment = TabAlignment.Top;
        }
        bool _border = true;
        public bool Border
        {
            get => _border;
            set
            {
                _border = value;
                Invalidate();
            }
        }

        int _Value = 1;
        public int Curv
        {
            get
            {
                var value = _Value;
                int Value;
                if (value != 0)
                {
                    Value = _Value;
                }
                else
                {
                    Value = 0;
                }
                return Value;
            }
            set
            {
                var num = value;
                _Value = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.Clear(Color.FromArgb(240, 240, 240));
            if (_border)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(240, 240, 255)), RoundRectangle.RoundRect(0, 0, Width - 1, 30, 2));

            }

            for (var TabIndex = 0; TabIndex <= TabCount - 1; TabIndex++)
            {
                GetTabRect(TabIndex);
                if (TabIndex != SelectedIndex)
                {
                    G.DrawString(TabPages[TabIndex].Text, new Font(Font.Name, Font.Size - 2, FontStyle.Regular), new SolidBrush(Color.DodgerBlue), new Rectangle(GetTabRect(TabIndex).Location, GetTabRect(TabIndex).Size), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
            }

            // Draw container rectangle

            G.FillPath(new SolidBrush(Color.FromArgb(240, 240, 240)), RoundRectangle.RoundRect(0, 30, Width - 1, Height - 24, 2));




            G.DrawPath(new Pen(Color.DodgerBlue), RoundRectangle.RoundRect(0, 29, Width - 1, Height - 30, 2));

            for (var ItemIndex = 0; ItemIndex <= TabCount - 1; ItemIndex++)
            {
                var ItemBoundsRect = GetTabRect(ItemIndex);
                if (ItemIndex == SelectedIndex)
                {

                    // Draw header tabs
                    G.DrawPath(new Pen(Color.DodgerBlue), RoundRectangle.RoundedTopRect(new Rectangle(new Point(ItemBoundsRect.X - 2, ItemBoundsRect.Y - 2), new Size(ItemBoundsRect.Width + 3, ItemBoundsRect.Height)), _Value));
                    G.FillPath(new SolidBrush(Color.FromArgb(240, 240, 240)), RoundRectangle.RoundedTopRect(new Rectangle(new Point(ItemBoundsRect.X - 1, ItemBoundsRect.Y - 1), new Size(ItemBoundsRect.Width + 2, ItemBoundsRect.Height)), _Value));

                    try
                    {
                        G.DrawString(TabPages[ItemIndex].Text, new Font(Font.Name, Font.Size, FontStyle.Regular), new SolidBrush(Color.FromArgb(0, 100, 255)), new Rectangle(GetTabRect(ItemIndex).Location, GetTabRect(ItemIndex).Size), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                        TabPages[ItemIndex].BackColor = Color.FromArgb(240, 240, 240);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }
    }
}