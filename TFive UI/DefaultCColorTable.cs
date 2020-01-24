using System.Drawing;

namespace TFive
{
    public class DefaultCColorTable : xColorTable
    {

        public override Color CheckedBackground => Color.DodgerBlue;

        public override Color CheckedSelectedBackground => Color.FromArgb(220, 230, 250);

        public override Color SelectionBorder => Color.DodgerBlue;

        public override Color SelectionTopGradient => Color.FromArgb(220, 230, 250);

        public override Color SelectionMidGradient => Color.FromArgb(220, 230, 250);

        public override Color SelectionBottomGradient => Color.FromArgb(220, 230, 250);

        public override Color PressedBackground => Color.FromArgb(255, 0, 0);

        public override Color TextColor => Color.FromArgb(0, 100, 255);

        public override Color Background => Color.FromArgb(240, 240, 240);

        public override Color DropdownBorder => Color.DodgerBlue;

        public override Color Arrow => Color.DodgerBlue;

        public override Color OverflowBackground => Color.FromArgb(240, 240, 240);
    }
}