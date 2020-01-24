using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveLinkLabel : LinkLabel
    {

        public TFiveLinkLabel()
        {
            Font = new Font("Segoe UI", 11, FontStyle.Regular);
            BackColor = Color.Transparent;
            LinkColor = Color.FromArgb(0, 200, 255);
            ActiveLinkColor = Color.FromArgb(0, 100, 255);
            VisitedLinkColor = Color.FromArgb(0, 200, 255);
            LinkBehavior = LinkBehavior.AlwaysUnderline;
        }
    }
}