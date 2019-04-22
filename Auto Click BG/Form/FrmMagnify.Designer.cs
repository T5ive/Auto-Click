namespace TFive_Auto_Click
{
    partial class FrmMagnify
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
            this.magnifyingGlass1 = new Magnifying_Glass.MagnifyingGlass();
            this.SuspendLayout();
            // 
            // magnifyingGlass1
            // 
            this.magnifyingGlass1.Location = new System.Drawing.Point(0, 0);
            this.magnifyingGlass1.Name = "magnifyingGlass1";
            this.magnifyingGlass1.PixelRange = 3;
            this.magnifyingGlass1.PixelSize = 21;
            this.magnifyingGlass1.Size = new System.Drawing.Size(147, 147);
            this.magnifyingGlass1.TabIndex = 0;
            this.magnifyingGlass1.UseMovingGlass = true;
            // 
            // FrmMagnify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(127, 127);
            this.Controls.Add(this.magnifyingGlass1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMagnify";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMagnify";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public Magnifying_Glass.MagnifyingGlass magnifyingGlass1;
    }
}