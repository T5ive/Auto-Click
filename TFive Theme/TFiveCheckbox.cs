using System;
using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveCheckbox : ThemeControl
    {
        public bool CheckedState
        {
            get => _CheckedState;
            set
            {
                _CheckedState = value;
                Invalidate();
            }
        }

        public TFiveCheckbox()
        {
            Click += delegate
            {
                changeCheck();
            };
            Size = new Size(90, 16);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Segoe UI", 11);
            CheckedState = false;
        }

        public override void PaintHook()
        {

            var border = new Pen(Color.DodgerBlue);
            G.Clear(Color.FromArgb(240, 240, 240));
            var checkedState = CheckedState;
            if (checkedState)
            {
                DrawGradient(Color.FromArgb(0, 100, 255), Color.FromArgb(0, 100, 255), 3, 3, 9, 9, 90f);
                DrawGradient(Color.DodgerBlue, Color.DodgerBlue, 4, 4, 7, 7, 90f);
            }
            else
            {
                DrawGradient(Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), 0, 0, 15, 15, 90f);
            }
            G.DrawRectangle(border, 0, 0, 14, 14);
            G.DrawRectangle(border, 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, Color.FromArgb(0, 100, 255), 17, 0);
        }

        public void changeCheck()
        {
            var checkedState = CheckedState;
            CheckedState = !checkedState;
        }

        private bool _CheckedState;
    }
}