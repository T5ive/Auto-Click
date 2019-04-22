using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveHeaderLabel : Label
    {

        public TFiveHeaderLabel()
        {
            Font = new Font("Segoe UI", 11, FontStyle.Bold);
            ForeColor = Color.FromArgb(0, 100, 255);
            BackColor = Color.Transparent;
        }
    }
}