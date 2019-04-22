using System.Windows.Forms;

namespace TFive_Auto_Click
{
    public partial class FrmMagnify : Form
    {
        public FrmMagnify()
        {
            InitializeComponent();
            magnifyingGlass1.UpdateTimer.Start();
        }

    }
}
