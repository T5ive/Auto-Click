namespace TFive_Auto_Click
{
    partial class FrmColorInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColorInfo));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tm_mouse = new System.Windows.Forms.Timer(this.components);
            this.tFive_Theme1 = new TFive.TFiveTheme();
            this.tFiveLabel1 = new TFive.TFiveLabel();
            this.txtDelay = new TFive.TFiveTextBox();
            this.lb_status = new TFive.TFiveLabel();
            this.panel_color = new System.Windows.Forms.Panel();
            this.txt_class = new TFive.TFiveTextBox();
            this.tFive_Label9 = new TFive.TFiveLabel();
            this.txt_color = new TFive.TFiveTextBox();
            this.txt_posiY = new TFive.TFiveTextBox();
            this.txt_posiX = new TFive.TFiveTextBox();
            this.txt_title = new TFive.TFiveTextBox();
            this.txt_clickX = new TFive.TFiveTextBox();
            this.txt_clickY = new TFive.TFiveTextBox();
            this.bt_cancel = new TFive.TFiveButton();
            this.bt_ok = new TFive.TFiveButton();
            this.tFive_Label2 = new TFive.TFiveLabel();
            this.tFive_Separator1 = new TFive.TFiveSeparator();
            this.picTarget = new System.Windows.Forms.PictureBox();
            this.tFive_Label3 = new TFive.TFiveLabel();
            this.tFive_Label4 = new TFive.TFiveLabel();
            this.tFive_Label5 = new TFive.TFiveLabel();
            this.tFive_Label6 = new TFive.TFiveLabel();
            this.tFive_Label7 = new TFive.TFiveLabel();
            this.tFive_Label8 = new TFive.TFiveLabel();
            this.num_click = new TFive.TFiveNumericUpDown();
            this.bt_add = new TFive.TFiveButton();
            this.LB_Position = new System.Windows.Forms.ListBox();
            this.pic_click = new System.Windows.Forms.PictureBox();
            this.tFive_TextBox1 = new TFive.TFiveTextBox();
            this.tFive_HeaderLabel1 = new TFive.TFiveHeaderLabel();
            this.tFive_Theme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_click)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // tm_mouse
            // 
            this.tm_mouse.Tick += new System.EventHandler(this.tm_mouse_Tick);
            // 
            // tFive_Theme1
            // 
            this.tFive_Theme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Theme1.Border = true;
            this.tFive_Theme1.Controls.Add(this.tFiveLabel1);
            this.tFive_Theme1.Controls.Add(this.txtDelay);
            this.tFive_Theme1.Controls.Add(this.lb_status);
            this.tFive_Theme1.Controls.Add(this.panel_color);
            this.tFive_Theme1.Controls.Add(this.txt_class);
            this.tFive_Theme1.Controls.Add(this.tFive_Label9);
            this.tFive_Theme1.Controls.Add(this.txt_color);
            this.tFive_Theme1.Controls.Add(this.txt_posiY);
            this.tFive_Theme1.Controls.Add(this.txt_posiX);
            this.tFive_Theme1.Controls.Add(this.txt_title);
            this.tFive_Theme1.Controls.Add(this.txt_clickX);
            this.tFive_Theme1.Controls.Add(this.txt_clickY);
            this.tFive_Theme1.Controls.Add(this.bt_cancel);
            this.tFive_Theme1.Controls.Add(this.bt_ok);
            this.tFive_Theme1.Controls.Add(this.tFive_Label2);
            this.tFive_Theme1.Controls.Add(this.tFive_Separator1);
            this.tFive_Theme1.Controls.Add(this.picTarget);
            this.tFive_Theme1.Controls.Add(this.tFive_Label3);
            this.tFive_Theme1.Controls.Add(this.tFive_Label4);
            this.tFive_Theme1.Controls.Add(this.tFive_Label5);
            this.tFive_Theme1.Controls.Add(this.tFive_Label6);
            this.tFive_Theme1.Controls.Add(this.tFive_Label7);
            this.tFive_Theme1.Controls.Add(this.tFive_Label8);
            this.tFive_Theme1.Controls.Add(this.num_click);
            this.tFive_Theme1.Controls.Add(this.bt_add);
            this.tFive_Theme1.Controls.Add(this.LB_Position);
            this.tFive_Theme1.Controls.Add(this.pic_click);
            this.tFive_Theme1.Controls.Add(this.tFive_TextBox1);
            this.tFive_Theme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFive_Theme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tFive_Theme1.Location = new System.Drawing.Point(0, 0);
            this.tFive_Theme1.Name = "tFive_Theme1";
            this.tFive_Theme1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.tFive_Theme1.RoundCorners = false;
            this.tFive_Theme1.Sizable = false;
            this.tFive_Theme1.Size = new System.Drawing.Size(349, 550);
            this.tFive_Theme1.SmartBounds = true;
            this.tFive_Theme1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.tFive_Theme1.TabIndex = 0;
            this.tFive_Theme1.Text = "Get Color";
            // 
            // tFiveLabel1
            // 
            this.tFiveLabel1.AutoSize = true;
            this.tFiveLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tFiveLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFiveLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFiveLabel1.Location = new System.Drawing.Point(80, 460);
            this.tFiveLabel1.Name = "tFiveLabel1";
            this.tFiveLabel1.Size = new System.Drawing.Size(50, 20);
            this.tFiveLabel1.TabIndex = 49;
            this.tFiveLabel1.Text = "Delay:";
            // 
            // txtDelay
            // 
            this.txtDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtDelay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDelay.Location = new System.Drawing.Point(137, 454);
            this.txtDelay.MaxLength = 32767;
            this.txtDelay.MinimumSize = new System.Drawing.Size(0, 31);
            this.txtDelay.Multiline = false;
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.ReadOnly = false;
            this.txtDelay.Size = new System.Drawing.Size(75, 31);
            this.txtDelay.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txtDelay.TabIndex = 48;
            this.txtDelay.Text = "100";
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDelay.UseSystemPasswordChar = false;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BackColor = System.Drawing.Color.Transparent;
            this.lb_status.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lb_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lb_status.Location = new System.Drawing.Point(272, 352);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(33, 12);
            this.lb_status.TabIndex = 46;
            this.lb_status.Text = "Status:";
            // 
            // panel_color
            // 
            this.panel_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.panel_color.Location = new System.Drawing.Point(23, 262);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(303, 89);
            this.panel_color.TabIndex = 44;
            // 
            // txt_class
            // 
            this.txt_class.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_class.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_class.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_class.Location = new System.Drawing.Point(137, 96);
            this.txt_class.MaxLength = 32767;
            this.txt_class.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_class.Multiline = false;
            this.txt_class.Name = "txt_class";
            this.txt_class.ReadOnly = false;
            this.txt_class.Size = new System.Drawing.Size(189, 31);
            this.txt_class.Style = TFive.TFiveTextBox._Num.TextNum;
            this.txt_class.TabIndex = 42;
            this.txt_class.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_class.UseSystemPasswordChar = false;
            // 
            // tFive_Label9
            // 
            this.tFive_Label9.AutoSize = true;
            this.tFive_Label9.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label9.Location = new System.Drawing.Point(42, 102);
            this.tFive_Label9.Name = "tFive_Label9";
            this.tFive_Label9.Size = new System.Drawing.Size(89, 20);
            this.tFive_Label9.TabIndex = 43;
            this.tFive_Label9.Text = "Class Name:";
            // 
            // txt_color
            // 
            this.txt_color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_color.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_color.Location = new System.Drawing.Point(137, 225);
            this.txt_color.MaxLength = 32767;
            this.txt_color.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_color.Multiline = false;
            this.txt_color.Name = "txt_color";
            this.txt_color.ReadOnly = true;
            this.txt_color.Size = new System.Drawing.Size(150, 31);
            this.txt_color.Style = TFive.TFiveTextBox._Num.TextNum;
            this.txt_color.TabIndex = 4;
            this.txt_color.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_color.UseSystemPasswordChar = false;
            // 
            // txt_posiY
            // 
            this.txt_posiY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_posiY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_posiY.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_posiY.Location = new System.Drawing.Point(229, 133);
            this.txt_posiY.MaxLength = 32767;
            this.txt_posiY.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_posiY.Multiline = false;
            this.txt_posiY.Name = "txt_posiY";
            this.txt_posiY.ReadOnly = false;
            this.txt_posiY.Size = new System.Drawing.Size(60, 31);
            this.txt_posiY.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_posiY.TabIndex = 3;
            this.txt_posiY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_posiY.UseSystemPasswordChar = false;
            // 
            // txt_posiX
            // 
            this.txt_posiX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_posiX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_posiX.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_posiX.Location = new System.Drawing.Point(137, 133);
            this.txt_posiX.MaxLength = 32767;
            this.txt_posiX.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_posiX.Multiline = false;
            this.txt_posiX.Name = "txt_posiX";
            this.txt_posiX.ReadOnly = false;
            this.txt_posiX.Size = new System.Drawing.Size(60, 31);
            this.txt_posiX.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_posiX.TabIndex = 2;
            this.txt_posiX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_posiX.UseSystemPasswordChar = false;
            // 
            // txt_title
            // 
            this.txt_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_title.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_title.Location = new System.Drawing.Point(137, 59);
            this.txt_title.MaxLength = 32767;
            this.txt_title.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_title.Multiline = false;
            this.txt_title.Name = "txt_title";
            this.txt_title.ReadOnly = false;
            this.txt_title.Size = new System.Drawing.Size(189, 31);
            this.txt_title.Style = TFive.TFiveTextBox._Num.TextNum;
            this.txt_title.TabIndex = 1;
            this.txt_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_title.UseSystemPasswordChar = false;
            // 
            // txt_clickX
            // 
            this.txt_clickX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_clickX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_clickX.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_clickX.Location = new System.Drawing.Point(137, 372);
            this.txt_clickX.MaxLength = 32767;
            this.txt_clickX.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_clickX.Multiline = false;
            this.txt_clickX.Name = "txt_clickX";
            this.txt_clickX.ReadOnly = false;
            this.txt_clickX.Size = new System.Drawing.Size(75, 31);
            this.txt_clickX.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_clickX.TabIndex = 21;
            this.txt_clickX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_clickX.UseSystemPasswordChar = false;
            // 
            // txt_clickY
            // 
            this.txt_clickY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_clickY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_clickY.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_clickY.Location = new System.Drawing.Point(251, 372);
            this.txt_clickY.MaxLength = 32767;
            this.txt_clickY.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_clickY.Multiline = false;
            this.txt_clickY.Name = "txt_clickY";
            this.txt_clickY.ReadOnly = false;
            this.txt_clickY.Size = new System.Drawing.Size(75, 31);
            this.txt_clickY.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_clickY.TabIndex = 22;
            this.txt_clickY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_clickY.UseSystemPasswordChar = false;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_cancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bt_cancel.Image = null;
            this.bt_cancel.Location = new System.Drawing.Point(252, 500);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.NoRounding = false;
            this.bt_cancel.Size = new System.Drawing.Size(75, 31);
            this.bt_cancel.TabIndex = 39;
            this.bt_cancel.Text = "CANCEL";
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bt_ok.Image = null;
            this.bt_ok.Location = new System.Drawing.Point(171, 500);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.NoRounding = false;
            this.bt_ok.Size = new System.Drawing.Size(75, 31);
            this.bt_ok.TabIndex = 38;
            this.bt_ok.Text = "OK";
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // tFive_Label2
            // 
            this.tFive_Label2.AutoSize = true;
            this.tFive_Label2.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label2.Location = new System.Drawing.Point(46, 65);
            this.tFive_Label2.Name = "tFive_Label2";
            this.tFive_Label2.Size = new System.Drawing.Size(85, 20);
            this.tFive_Label2.TabIndex = 25;
            this.tFive_Label2.Text = "Title Name:";
            // 
            // tFive_Separator1
            // 
            this.tFive_Separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Separator1.Location = new System.Drawing.Point(23, 357);
            this.tFive_Separator1.Name = "tFive_Separator1";
            this.tFive_Separator1.Size = new System.Drawing.Size(303, 10);
            this.tFive_Separator1.TabIndex = 20;
            this.tFive_Separator1.Text = "tFive_Separator1";
            // 
            // picTarget
            // 
            this.picTarget.BackColor = System.Drawing.Color.White;
            this.picTarget.Image = ((System.Drawing.Image)(resources.GetObject("picTarget.Image")));
            this.picTarget.Location = new System.Drawing.Point(295, 228);
            this.picTarget.Name = "picTarget";
            this.picTarget.Size = new System.Drawing.Size(31, 28);
            this.picTarget.TabIndex = 19;
            this.picTarget.TabStop = false;
            this.picTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTarget_MouseDown);
            this.picTarget.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picTarget_MouseUp);
            // 
            // tFive_Label3
            // 
            this.tFive_Label3.AutoSize = true;
            this.tFive_Label3.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label3.Location = new System.Drawing.Point(57, 139);
            this.tFive_Label3.Name = "tFive_Label3";
            this.tFive_Label3.Size = new System.Drawing.Size(77, 20);
            this.tFive_Label3.TabIndex = 26;
            this.tFive_Label3.Text = "Position X:";
            // 
            // tFive_Label4
            // 
            this.tFive_Label4.AutoSize = true;
            this.tFive_Label4.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label4.Location = new System.Drawing.Point(206, 139);
            this.tFive_Label4.Name = "tFive_Label4";
            this.tFive_Label4.Size = new System.Drawing.Size(20, 20);
            this.tFive_Label4.TabIndex = 27;
            this.tFive_Label4.Text = "Y:";
            // 
            // tFive_Label5
            // 
            this.tFive_Label5.AutoSize = true;
            this.tFive_Label5.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label5.Location = new System.Drawing.Point(86, 229);
            this.tFive_Label5.Name = "tFive_Label5";
            this.tFive_Label5.Size = new System.Drawing.Size(48, 20);
            this.tFive_Label5.TabIndex = 28;
            this.tFive_Label5.Text = "Color:";
            // 
            // tFive_Label6
            // 
            this.tFive_Label6.AutoSize = true;
            this.tFive_Label6.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label6.Location = new System.Drawing.Point(54, 378);
            this.tFive_Label6.Name = "tFive_Label6";
            this.tFive_Label6.Size = new System.Drawing.Size(77, 20);
            this.tFive_Label6.TabIndex = 29;
            this.tFive_Label6.Text = "Position X:";
            // 
            // tFive_Label7
            // 
            this.tFive_Label7.AutoSize = true;
            this.tFive_Label7.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label7.Location = new System.Drawing.Point(228, 378);
            this.tFive_Label7.Name = "tFive_Label7";
            this.tFive_Label7.Size = new System.Drawing.Size(20, 20);
            this.tFive_Label7.TabIndex = 30;
            this.tFive_Label7.Text = "Y:";
            // 
            // tFive_Label8
            // 
            this.tFive_Label8.AutoSize = true;
            this.tFive_Label8.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label8.Location = new System.Drawing.Point(80, 419);
            this.tFive_Label8.Name = "tFive_Label8";
            this.tFive_Label8.Size = new System.Drawing.Size(51, 20);
            this.tFive_Label8.TabIndex = 33;
            this.tFive_Label8.Text = "Times:";
            // 
            // num_click
            // 
            this.num_click.BackColor = System.Drawing.Color.Transparent;
            this.num_click.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.num_click.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.num_click.Location = new System.Drawing.Point(137, 415);
            this.num_click.Maximum = ((long)(10));
            this.num_click.Minimum = ((long)(1));
            this.num_click.MinimumSize = new System.Drawing.Size(93, 28);
            this.num_click.Name = "num_click";
            this.num_click.Size = new System.Drawing.Size(111, 28);
            this.num_click.TabIndex = 34;
            this.num_click.Text = "tFive_NumericUpDown1";
            this.num_click.TextAlignment = TFive.TFiveNumericUpDown._TextAlignment.Near;
            this.num_click.Value = ((long)(1));
            // 
            // bt_add
            // 
            this.bt_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.bt_add.Image = null;
            this.bt_add.Location = new System.Drawing.Point(295, 133);
            this.bt_add.Name = "bt_add";
            this.bt_add.NoRounding = false;
            this.bt_add.Size = new System.Drawing.Size(31, 31);
            this.bt_add.TabIndex = 36;
            this.bt_add.Text = "+";
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // LB_Position
            // 
            this.LB_Position.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.LB_Position.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LB_Position.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.LB_Position.FormattingEnabled = true;
            this.LB_Position.ItemHeight = 15;
            this.LB_Position.Location = new System.Drawing.Point(23, 170);
            this.LB_Position.Name = "LB_Position";
            this.LB_Position.Size = new System.Drawing.Size(303, 45);
            this.LB_Position.TabIndex = 37;
            this.LB_Position.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LB_Position_KeyDown);
            // 
            // pic_click
            // 
            this.pic_click.BackColor = System.Drawing.Color.White;
            this.pic_click.Image = ((System.Drawing.Image)(resources.GetObject("pic_click.Image")));
            this.pic_click.Location = new System.Drawing.Point(295, 415);
            this.pic_click.Name = "pic_click";
            this.pic_click.Size = new System.Drawing.Size(31, 28);
            this.pic_click.TabIndex = 40;
            this.pic_click.TabStop = false;
            this.pic_click.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_click_MouseDown);
            this.pic_click.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_click_MouseUp);
            // 
            // tFive_TextBox1
            // 
            this.tFive_TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tFive_TextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_TextBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_TextBox1.Location = new System.Drawing.Point(22, 169);
            this.tFive_TextBox1.MaxLength = 32767;
            this.tFive_TextBox1.MinimumSize = new System.Drawing.Size(0, 31);
            this.tFive_TextBox1.Multiline = true;
            this.tFive_TextBox1.Name = "tFive_TextBox1";
            this.tFive_TextBox1.ReadOnly = false;
            this.tFive_TextBox1.Size = new System.Drawing.Size(305, 49);
            this.tFive_TextBox1.Style = TFive.TFiveTextBox._Num.TextNum;
            this.tFive_TextBox1.TabIndex = 45;
            this.tFive_TextBox1.Text = "tFive_TextBox1";
            this.tFive_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tFive_TextBox1.UseSystemPasswordChar = false;
            // 
            // tFive_HeaderLabel1
            // 
            this.tFive_HeaderLabel1.AutoSize = true;
            this.tFive_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tFive_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tFive_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_HeaderLabel1.Location = new System.Drawing.Point(136, 364);
            this.tFive_HeaderLabel1.Name = "tFive_HeaderLabel1";
            this.tFive_HeaderLabel1.Size = new System.Drawing.Size(66, 20);
            this.tFive_HeaderLabel1.TabIndex = 31;
            this.tFive_HeaderLabel1.Text = "Settings";
            // 
            // FrmColorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(349, 550);
            this.Controls.Add(this.tFive_Theme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "FrmColorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Get Color";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmColorInfo_FormClosing);
            this.Load += new System.EventHandler(this.GetColor_Load);
            this.tFive_Theme1.ResumeLayout(false);
            this.tFive_Theme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_click)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion



        private TFive.TFiveTheme tFive_Theme1;
        private TFive.TFiveLabel tFive_Label2;
        private TFive.TFiveTextBox txt_clickY;
        private TFive.TFiveTextBox txt_clickX;
        private TFive.TFiveSeparator tFive_Separator1;
        private System.Windows.Forms.PictureBox picTarget;
        private TFive.TFiveTextBox txt_color;
        private TFive.TFiveTextBox txt_posiY;
        private TFive.TFiveTextBox txt_posiX;
        private TFive.TFiveTextBox txt_title;
        private TFive.TFiveLabel tFive_Label4;
        private TFive.TFiveLabel tFive_Label3;
        private TFive.TFiveLabel tFive_Label5;
        private TFive.TFiveLabel tFive_Label7;
        private TFive.TFiveLabel tFive_Label6;
        private TFive.TFiveHeaderLabel tFive_HeaderLabel1;
        private TFive.TFiveLabel tFive_Label8;
        private TFive.TFiveNumericUpDown num_click;
        private TFive.TFiveButton bt_add;
        private System.Windows.Forms.ListBox LB_Position;
        private TFive.TFiveButton bt_cancel;
        private TFive.TFiveButton bt_ok;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pic_click;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer tm_mouse;
        private TFive.TFiveTextBox txt_class;
        private TFive.TFiveLabel tFive_Label9;
        private System.Windows.Forms.Panel panel_color;
        private TFive.TFiveTextBox tFive_TextBox1;
        private TFive.TFiveLabel lb_status;
        private TFive.TFiveLabel tFiveLabel1;
        private TFive.TFiveTextBox txtDelay;
    }
}