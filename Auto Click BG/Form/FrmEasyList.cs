using System;
using System.IO;
using System.Windows.Forms;

namespace TFive_Auto_Click
{
    public partial class FrmEasyList : Form
    {
        public FrmEasyList()
        {
            InitializeComponent();
        }


        private void tFive_Button1_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private string pathFile;
        private void OpenFolder()
        {
            var folderPicker = new FolderBrowserDialog();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            folderPicker.SelectedPath = Directory.Exists(path) ? path : @"C:\";
            if (folderPicker.ShowDialog() != DialogResult.OK) return;
            listView1.Items.Clear();
            pathFile = folderPicker.SelectedPath;
            var files = Directory.GetFiles(folderPicker.SelectedPath, "*.t5proj");
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var item = new ListViewItem(fileName) { Tag = file };
                listView1.Items.Add(item);

            }
        }

        
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;
            var item = listView1.SelectedItems[0].SubItems[0].Text;

           Values.PathFile = pathFile + @"\" + item + @".t5proj";
            var FrmMain = new FrmMain();
            FrmMain.OpenProjects(2);
           
           // MessageBox.Show(pathFile + @"\" + item + @".t5proj");
        }
    }
}
