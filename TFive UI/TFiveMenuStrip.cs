using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveMenuStrip : MenuStrip
    {

        public TFiveMenuStrip()
        {

            Renderer = new ControlRenderer();
            Font = new Font("Segoe UI", 12);
            Size = new Size(0, 30);
            MinimumSize = new Size(0, 30);
        }

        public new ControlRenderer Renderer
        {
            get => (ControlRenderer)base.Renderer;
            set => base.Renderer = value;
        }

    }
}