using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveContextMenuStrip : ContextMenuStrip
    {

        public TFiveContextMenuStrip()
        {
            Renderer = new ControlRenderer();
            Font = new Font("Segoe UI", 11);
        }

        public new ControlRenderer Renderer
        {
            get => (ControlRenderer)base.Renderer;
            set => base.Renderer = value;
        }
    }
}