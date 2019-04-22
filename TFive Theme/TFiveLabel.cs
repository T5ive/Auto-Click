using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveLabel : Label
    {

        public TFiveLabel()
        {
            Font = new Font("Segoe UI", 11);
            ForeColor = Color.FromArgb(0, 100, 255);
            BackColor = Color.Transparent;
        }
    }
}