namespace TFive_Auto_Click
{
    partial class FrmEasyList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tFive_Theme1 = new TFive.TFiveTheme();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilLarge = new System.Windows.Forms.ImageList(this.components);
            this.ilSmall = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tFive_Button1 = new TFive.TFiveButton();
            this.tFive_ControlBox1 = new TFive.TFiveControlBox();
            this.tFive_Theme1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tFive_Theme1
            // 
            this.tFive_Theme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Theme1.Border = true;
            this.tFive_Theme1.Controls.Add(this.panel2);
            this.tFive_Theme1.Controls.Add(this.panel1);
            this.tFive_Theme1.Controls.Add(this.tFive_ControlBox1);
            this.tFive_Theme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFive_Theme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tFive_Theme1.Location = new System.Drawing.Point(0, 0);
            this.tFive_Theme1.Name = "tFive_Theme1";
            this.tFive_Theme1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.tFive_Theme1.RoundCorners = false;
            this.tFive_Theme1.Sizable = true;
            this.tFive_Theme1.Size = new System.Drawing.Size(368, 419);
            this.tFive_Theme1.SmartBounds = false;
            this.tFive_Theme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tFive_Theme1.TabIndex = 0;
            this.tFive_Theme1.Text = "Open";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 56);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15, 15, 15, 7);
            this.panel2.Size = new System.Drawing.Size(328, 283);
            this.panel2.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.listView1.LargeImageList = this.ilLarge;
            this.listView1.Location = new System.Drawing.Point(15, 15);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(298, 261);
            this.listView1.SmallImageList = this.ilSmall;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Files Name";
            this.columnHeader1.Width = 275;
            // 
            // ilLarge
            // 
            this.ilLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.ilLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ilLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ilSmall
            // 
            this.ilSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ilSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tFive_Button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 339);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 7, 15, 15);
            this.panel1.Size = new System.Drawing.Size(328, 64);
            this.panel1.TabIndex = 1;
            // 
            // tFive_Button1
            // 
            this.tFive_Button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFive_Button1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Button1.Image = null;
            this.tFive_Button1.Location = new System.Drawing.Point(15, 7);
            this.tFive_Button1.Name = "tFive_Button1";
            this.tFive_Button1.NoRounding = false;
            this.tFive_Button1.Size = new System.Drawing.Size(298, 42);
            this.tFive_Button1.TabIndex = 0;
            this.tFive_Button1.Text = "Open Folder";
            this.tFive_Button1.Click += new System.EventHandler(this.tFive_Button1_Click);
            // 
            // tFive_ControlBox1
            // 
            this.tFive_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.tFive_ControlBox1.EnableMaximize = false;
            this.tFive_ControlBox1.Font = new System.Drawing.Font("Marlett", 7F);
            this.tFive_ControlBox1.Location = new System.Drawing.Point(5, 13);
            this.tFive_ControlBox1.Name = "tFive_ControlBox1";
            this.tFive_ControlBox1.Size = new System.Drawing.Size(44, 22);
            this.tFive_ControlBox1.TabIndex = 0;
            this.tFive_ControlBox1.Text = "tFive_ControlBox1";
            // 
            // FrmEasyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 419);
            this.Controls.Add(this.tFive_Theme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "FrmEasyList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.tFive_Theme1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TFive.TFiveTheme tFive_Theme1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private TFive.TFiveButton tFive_Button1;
        private TFive.TFiveControlBox tFive_ControlBox1;
        private System.Windows.Forms.ImageList ilLarge;
        private System.Windows.Forms.ImageList ilSmall;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}