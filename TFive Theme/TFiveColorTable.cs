using System.Drawing;

namespace TFive
{
    public class TFiveColorTable : ColorTable
    {
        public TFiveColorTable()
        {

            CommonColorTable = new DefaultCColorTable();

        }

        public override xColorTable CommonColorTable { get; }

        public override Color BackgroundTopGradient => Color.FromArgb(240, 240, 240);

        public override Color BackgroundBottomGradient => Color.FromArgb(240, 240, 240);

        public override Color DropdownTopGradient => Color.FromArgb(240, 240, 240);

        public override Color DropdownBottomGradient => Color.FromArgb(240, 240, 240);

        public override Color DroppedDownItemBackground => Color.FromArgb(220, 230, 250);

        public override Color Separator => Color.FromArgb(0, 100, 255);

        public override Color ImageMargin => Color.FromArgb(220, 230, 250);
    }
}