using System;
using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveOnlyCheck : ThemeControl
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

        public TFiveOnlyCheck()
        {
            Click += delegate
            {
                changeCheck();
            };
            Size = new Size(30, 30);
            MinimumSize = new Size(15, 15);
            MaximumSize = new Size(60, 60);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckedState = false;
        }

        public override void PaintHook()
        {
            var border = new Pen(Color.DodgerBlue);
            G.Clear(Color.FromArgb(220, 230, 250));
            var checkedState = CheckedState;
            if (checkedState)
            {
                DrawGradient(Color.FromArgb(0, 100, 255), Color.FromArgb(0, 100, 255), 4, 4, Size.Width - 9, Size.Height - 9, 90f);
                DrawGradient(Color.DodgerBlue, Color.DodgerBlue, 5, 5, Size.Width - 11, Size.Height - 11, 90f);
            }
            else
            {
                DrawGradient(Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), 0, 0, Size.Width + 1, Size.Height + 1, 90f);
            }
            G.DrawRectangle(border, 0, 0, Size.Width - 2, Size.Height - 2);
            G.DrawRectangle(border, 0, 0, Size.Width - 2, Size.Height - 2);
        }

        public void changeCheck()
        {
            var checkedState = CheckedState;
            CheckedState = !checkedState;
        }

        private bool _CheckedState;
    }
}