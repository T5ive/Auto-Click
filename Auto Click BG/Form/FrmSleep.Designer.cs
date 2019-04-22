namespace TFive_Auto_Click
{
    partial class FrmSleep
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
            this.tFive_Theme1 = new TFive.TFiveTheme();
            this.bt_cancel = new TFive.TFiveButton();
            this.tFive_Label1 = new TFive.TFiveLabel();
            this.txt_time = new TFive.TFiveTextBox();
            this.bt_add = new TFive.TFiveButton();
            this.tFive_Theme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tFive_Theme1
            // 
            this.tFive_Theme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Theme1.Border = true;
            this.tFive_Theme1.Controls.Add(this.bt_cancel);
            this.tFive_Theme1.Controls.Add(this.tFive_Label1);
            this.tFive_Theme1.Controls.Add(this.txt_time);
            this.tFive_Theme1.Controls.Add(this.bt_add);
            this.tFive_Theme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFive_Theme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tFive_Theme1.Location = new System.Drawing.Point(0, 0);
            this.tFive_Theme1.Name = "tFive_Theme1";
            this.tFive_Theme1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.tFive_Theme1.RoundCorners = false;
            this.tFive_Theme1.Sizable = false;
            this.tFive_Theme1.Size = new System.Drawing.Size(261, 160);
            this.tFive_Theme1.SmartBounds = true;
            this.tFive_Theme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tFive_Theme1.TabIndex = 0;
            this.tFive_Theme1.Text = "Sleep";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bt_cancel.Image = null;
            this.bt_cancel.Location = new System.Drawing.Point(148, 113);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.NoRounding = false;
            this.bt_cancel.Size = new System.Drawing.Size(90, 28);
            this.bt_cancel.TabIndex = 4;
            this.bt_cancel.Text = "CANCEL";
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // tFive_Label1
            // 
            this.tFive_Label1.AutoSize = true;
            this.tFive_Label1.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label1.Location = new System.Drawing.Point(80, 53);
            this.tFive_Label1.Name = "tFive_Label1";
            this.tFive_Label1.Size = new System.Drawing.Size(94, 20);
            this.tFive_Label1.TabIndex = 3;
            this.tFive_Label1.Text = "1000 = 1 Sec";
            // 
            // txt_time
            // 
            this.txt_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_time.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_time.Location = new System.Drawing.Point(23, 76);
            this.txt_time.MaxLength = 32767;
            this.txt_time.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_time.Multiline = false;
            this.txt_time.Name = "txt_time";
            this.txt_time.ReadOnly = false;
            this.txt_time.Size = new System.Drawing.Size(215, 31);
            this.txt_time.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_time.TabIndex = 2;
            this.txt_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_time.UseSystemPasswordChar = false;
            // 
            // bt_add
            // 
            this.bt_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bt_add.Image = null;
            this.bt_add.Location = new System.Drawing.Point(23, 113);
            this.bt_add.Name = "bt_add";
            this.bt_add.NoRounding = false;
            this.bt_add.Size = new System.Drawing.Size(90, 28);
            this.bt_add.TabIndex = 1;
            this.bt_add.Text = "OK";
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // FrmSleep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 160);
            this.Controls.Add(this.tFive_Theme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "FrmSleep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sleep";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frm_sleep_Load);
            this.tFive_Theme1.ResumeLayout(false);
            this.tFive_Theme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TFive.TFiveTheme tFive_Theme1;
        private TFive.TFiveLabel tFive_Label1;
        private TFive.TFiveTextBox txt_time;
        private TFive.TFiveButton bt_add;
        private TFive.TFiveButton bt_cancel;
    }
}