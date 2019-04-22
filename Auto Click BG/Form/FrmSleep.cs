using System;
using System.Windows.Forms;

namespace TFive_Auto_Click
{
    public partial class FrmSleep : Form
    {
        public FrmSleep()
        {
            InitializeComponent();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {            
                add_sleep();
        }
        private void add_sleep()
        {
            if (!string.IsNullOrEmpty(txt_time.Text))
            {
                Values.sleep = int.Parse(txt_time.Text);
            Values.CloseFrom = true;
                Close();
            }
            else
            {
                MessageBox.Show(@"Please Input Number", @"TFive Auto Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Values.CloseFrom = false;
            Close();
        }

        private void frm_sleep_Load(object sender, EventArgs e)
        {
            txt_time.Focus();
        }
    }
}
