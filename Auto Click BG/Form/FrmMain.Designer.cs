using System.Windows.Forms;

namespace TFive_Auto_Click
{
    partial class FrmMain
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
            TFive.ControlRenderer controlRenderer1 = new TFive.ControlRenderer();
            TFive.TFiveColorTable tFiveColorTable1 = new TFive.TFiveColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Bots_Worker = new System.ComponentModel.BackgroundWorker();
            this.tFiveTheme = new TFive.TFiveTheme();
            this.TFiveTabControl = new TFive.TFiveTabControl();
            this.tabProj = new System.Windows.Forms.TabPage();
            this.panel_protect = new System.Windows.Forms.Panel();
            this.txt_creator = new TFive_Theme.TFiveMarquee();
            this.gbAutoClick = new TFive.TFiveGroupBox();
            this.GridProcess = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posi_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posi_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.click_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.click_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timesClick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabStart = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.gbShowHide = new TFive.TFiveGroupBox();
            this.panel_game = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.combo_process = new TFive.TFiveComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.toggle_ShowHide = new TFive.TFiveToggle();
            this.bt_start_stop = new TFive.TFiveButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.gbLogs = new TFive.TFiveGroupBox();
            this.logs_box = new System.Windows.Forms.RichTextBox();
            this.gbLoop = new TFive.TFiveGroupBox();
            this.txt_numDelay = new TFive.TFiveTextBox();
            this.txt_numTimes = new TFive.TFiveTextBox();
            this.txt_delay = new TFive.TFiveTextBox();
            this.lbDelay = new TFive.TFiveLabel();
            this.tFive_Separator4 = new TFive.TFiveSeparator();
            this.lb_loopInter = new TFive.TFiveLabel();
            this.tFive_Separator1 = new TFive.TFiveSeparator();
            this.radio_loopNonStop = new TFive.TFiveRadioButton();
            this.radio_loop_time = new TFive.TFiveRadioButton();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tFive_TextBox1 = new TFive.TFiveTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLanguageAuthor = new TFive.TFiveLabel();
            this.gbSettings = new TFive.TFiveGroupBox();
            this.cb_logs = new TFive.TFiveCheckbox();
            this.comboStart = new TFive.TFiveComboBox();
            this.lbLang = new TFive.TFiveLabel();
            this.cbbLanguages = new TFive.TFiveComboBox();
            this.lbHotkey = new TFive.TFiveLabel();
            this.cb_topMost = new TFive.TFiveCheckbox();
            this.tFive_Label3 = new TFive.TFiveLabel();
            this.tFive_Label2 = new TFive.TFiveLabel();
            this.tFive_Separator3 = new TFive.TFiveSeparator();
            this.tFive_Separator2 = new TFive.TFiveSeparator();
            this.cb_easyList = new TFive.TFiveCheckbox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbVersion = new TFive.TFiveLabel();
            this.tFive_HeaderLabel1 = new TFive.TFiveHeaderLabel();
            this.tFiveMenuStrip = new TFive.TFiveMenuStrip();
            this.newProject = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendKeysBGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.messageBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.intToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetIntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToByIntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.devoloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protectCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.registerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_checkHK = new System.Windows.Forms.Timer(this.components);
            this.tFiveTheme.SuspendLayout();
            this.TFiveTabControl.SuspendLayout();
            this.tabProj.SuspendLayout();
            this.panel_protect.SuspendLayout();
            this.gbAutoClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridProcess)).BeginInit();
            this.tabStart.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.gbShowHide.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.gbLogs.SuspendLayout();
            this.gbLoop.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tFiveMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.CheckPathExists = false;
            this.openFileDialog1.DefaultExt = "t5proj";
            this.openFileDialog1.Filter = "ConfuserEx Projects (*.t5proj)|*.t5proj|All Files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Load Files";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckPathExists = false;
            this.saveFileDialog1.DefaultExt = "t5proj";
            this.saveFileDialog1.Filter = "ConfuserEx Projects (*.t5proj)|*.t5proj|All Files (*.*)|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save Files";
            // 
            // Bots_Worker
            // 
            this.Bots_Worker.WorkerReportsProgress = true;
            this.Bots_Worker.WorkerSupportsCancellation = true;
            this.Bots_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bots_Worker_DoWork);
            // 
            // tFiveTheme
            // 
            this.tFiveTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFiveTheme.Border = false;
            this.tFiveTheme.Controls.Add(this.TFiveTabControl);
            this.tFiveTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFiveTheme.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tFiveTheme.Location = new System.Drawing.Point(0, 30);
            this.tFiveTheme.Name = "tFiveTheme";
            this.tFiveTheme.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.tFiveTheme.RoundCorners = false;
            this.tFiveTheme.Sizable = false;
            this.tFiveTheme.Size = new System.Drawing.Size(691, 458);
            this.tFiveTheme.SmartBounds = true;
            this.tFiveTheme.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.tFiveTheme.TabIndex = 2;
            // 
            // TFiveTabControl
            // 
            this.TFiveTabControl.Border = true;
            this.TFiveTabControl.Controls.Add(this.tabProj);
            this.TFiveTabControl.Controls.Add(this.tabStart);
            this.TFiveTabControl.Controls.Add(this.tabAbout);
            this.TFiveTabControl.Curv = 1;
            this.TFiveTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TFiveTabControl.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TFiveTabControl.ItemSize = new System.Drawing.Size(330, 30);
            this.TFiveTabControl.Location = new System.Drawing.Point(20, 16);
            this.TFiveTabControl.Name = "TFiveTabControl";
            this.TFiveTabControl.SelectedIndex = 0;
            this.TFiveTabControl.Size = new System.Drawing.Size(651, 426);
            this.TFiveTabControl.TabIndex = 0;
            // 
            // tabProj
            // 
            this.tabProj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabProj.Controls.Add(this.panel_protect);
            this.tabProj.Controls.Add(this.gbAutoClick);
            this.tabProj.Location = new System.Drawing.Point(4, 34);
            this.tabProj.Name = "tabProj";
            this.tabProj.Padding = new System.Windows.Forms.Padding(15);
            this.tabProj.Size = new System.Drawing.Size(643, 388);
            this.tabProj.TabIndex = 0;
            this.tabProj.Text = "Project";
            // 
            // panel_protect
            // 
            this.panel_protect.Controls.Add(this.txt_creator);
            this.panel_protect.Location = new System.Drawing.Point(616, 3);
            this.panel_protect.Name = "panel_protect";
            this.panel_protect.Padding = new System.Windows.Forms.Padding(30);
            this.panel_protect.Size = new System.Drawing.Size(24, 20);
            this.panel_protect.TabIndex = 1;
            // 
            // txt_creator
            // 
            this.txt_creator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_creator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_creator.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F);
            this.txt_creator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.txt_creator.Location = new System.Drawing.Point(30, 30);
            this.txt_creator.Name = "txt_creator";
            this.txt_creator.Size = new System.Drawing.Size(0, 0);
            this.txt_creator.TabIndex = 0;
            this.txt_creator.Text = "TFive";
            // 
            // gbAutoClick
            // 
            this.gbAutoClick.BackColor = System.Drawing.Color.Transparent;
            this.gbAutoClick.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbAutoClick.Controls.Add(this.GridProcess);
            this.gbAutoClick.Curv1 = 1;
            this.gbAutoClick.Curv2 = 2;
            this.gbAutoClick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAutoClick.Location = new System.Drawing.Point(15, 15);
            this.gbAutoClick.MinimumSize = new System.Drawing.Size(136, 50);
            this.gbAutoClick.Name = "gbAutoClick";
            this.gbAutoClick.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.gbAutoClick.Size = new System.Drawing.Size(613, 358);
            this.gbAutoClick.TabIndex = 0;
            this.gbAutoClick.Text = "Auto Click";
            // 
            // GridProcess
            // 
            this.GridProcess.AllowUserToAddRows = false;
            this.GridProcess.AllowUserToDeleteRows = false;
            this.GridProcess.AllowUserToResizeColumns = false;
            this.GridProcess.AllowUserToResizeRows = false;
            this.GridProcess.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.GridProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.process,
            this.process_name,
            this.posi_x,
            this.posi_y,
            this.check_color,
            this.click_x,
            this.click_y,
            this.timesClick,
            this.NumList,
            this.mode});
            this.GridProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridProcess.Location = new System.Drawing.Point(10, 30);
            this.GridProcess.Name = "GridProcess";
            this.GridProcess.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridProcess.RowHeadersVisible = false;
            this.GridProcess.RowHeadersWidth = 45;
            this.GridProcess.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridProcess.Size = new System.Drawing.Size(593, 318);
            this.GridProcess.TabIndex = 1;
            this.GridProcess.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProcess_CellValueChanged);
            this.GridProcess.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.GridProcess_SortCompare);
            this.GridProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridProcess_KeyDown);
            // 
            // No
            // 
            this.No.HeaderText = "No.";
            this.No.MinimumWidth = 30;
            this.No.Name = "No";
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.Width = 40;
            // 
            // process
            // 
            this.process.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.process.HeaderText = "Processes Name";
            this.process.Name = "process";
            this.process.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.process.Width = 122;
            // 
            // process_name
            // 
            this.process_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.process_name.HeaderText = "Target Title";
            this.process_name.Name = "process_name";
            this.process_name.ReadOnly = true;
            this.process_name.Width = 108;
            // 
            // posi_x
            // 
            this.posi_x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.posi_x.HeaderText = "Color X";
            this.posi_x.Name = "posi_x";
            this.posi_x.ReadOnly = true;
            this.posi_x.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.posi_x.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.posi_x.Width = 64;
            // 
            // posi_y
            // 
            this.posi_y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.posi_y.HeaderText = "Color Y";
            this.posi_y.Name = "posi_y";
            this.posi_y.ReadOnly = true;
            this.posi_y.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.posi_y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.posi_y.Width = 63;
            // 
            // check_color
            // 
            this.check_color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.check_color.HeaderText = "Color";
            this.check_color.Name = "check_color";
            this.check_color.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.check_color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.check_color.Width = 51;
            // 
            // click_x
            // 
            this.click_x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.click_x.HeaderText = "Click X";
            this.click_x.Name = "click_x";
            this.click_x.ReadOnly = true;
            this.click_x.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.click_x.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.click_x.Width = 59;
            // 
            // click_y
            // 
            this.click_y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.click_y.HeaderText = "Click Y";
            this.click_y.Name = "click_y";
            this.click_y.ReadOnly = true;
            this.click_y.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.click_y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.click_y.Width = 58;
            // 
            // timesClick
            // 
            this.timesClick.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timesClick.HeaderText = "Click";
            this.timesClick.Name = "timesClick";
            this.timesClick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.timesClick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.timesClick.Width = 46;
            // 
            // NumList
            // 
            this.NumList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumList.HeaderText = "Point";
            this.NumList.Name = "NumList";
            this.NumList.ReadOnly = true;
            this.NumList.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NumList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumList.Width = 48;
            // 
            // mode
            // 
            this.mode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mode.HeaderText = "Mode";
            this.mode.Name = "mode";
            this.mode.ReadOnly = true;
            this.mode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mode.Width = 54;
            // 
            // tabStart
            // 
            this.tabStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabStart.Controls.Add(this.panel1);
            this.tabStart.Controls.Add(this.panel2);
            this.tabStart.Location = new System.Drawing.Point(4, 34);
            this.tabStart.Name = "tabStart";
            this.tabStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabStart.Size = new System.Drawing.Size(643, 388);
            this.tabStart.TabIndex = 1;
            this.tabStart.Text = "Start";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.bt_start_stop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(271, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(369, 382);
            this.panel1.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.gbShowHide);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(10, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel9.Size = new System.Drawing.Size(359, 332);
            this.panel9.TabIndex = 2;
            // 
            // gbShowHide
            // 
            this.gbShowHide.BackColor = System.Drawing.Color.Transparent;
            this.gbShowHide.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbShowHide.Controls.Add(this.panel_game);
            this.gbShowHide.Controls.Add(this.panel5);
            this.gbShowHide.Curv1 = 1;
            this.gbShowHide.Curv2 = 2;
            this.gbShowHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbShowHide.Location = new System.Drawing.Point(0, 0);
            this.gbShowHide.MinimumSize = new System.Drawing.Size(136, 50);
            this.gbShowHide.Name = "gbShowHide";
            this.gbShowHide.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.gbShowHide.Size = new System.Drawing.Size(359, 322);
            this.gbShowHide.TabIndex = 2;
            this.gbShowHide.Text = "Show/Hide Process";
            // 
            // panel_game
            // 
            this.panel_game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_game.Location = new System.Drawing.Point(5, 80);
            this.panel_game.Name = "panel_game";
            this.panel_game.Size = new System.Drawing.Size(349, 237);
            this.panel_game.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 28);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.panel5.Size = new System.Drawing.Size(349, 52);
            this.panel5.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.combo_process);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(5, 5);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5);
            this.panel7.Size = new System.Drawing.Size(257, 42);
            this.panel7.TabIndex = 5;
            // 
            // combo_process
            // 
            this.combo_process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.combo_process.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.combo_process.Curv = 1;
            this.combo_process.Dock = System.Windows.Forms.DockStyle.Top;
            this.combo_process.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_process.DropDownHeight = 100;
            this.combo_process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_process.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.combo_process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.combo_process.FormattingEnabled = true;
            this.combo_process.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.combo_process.IntegralHeight = false;
            this.combo_process.ItemHeight = 20;
            this.combo_process.Location = new System.Drawing.Point(5, 5);
            this.combo_process.Name = "combo_process";
            this.combo_process.Size = new System.Drawing.Size(247, 26);
            this.combo_process.StartIndex = 0;
            this.combo_process.TabIndex = 0;
            this.combo_process.SelectedIndexChanged += new System.EventHandler(this.combo_process_SelectedIndexChanged_1);
            this.combo_process.Click += new System.EventHandler(this.combo_process_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.toggle_ShowHide);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(262, 5);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(87, 42);
            this.panel6.TabIndex = 4;
            // 
            // toggle_ShowHide
            // 
            this.toggle_ShowHide.Dock = System.Windows.Forms.DockStyle.Top;
            this.toggle_ShowHide.Location = new System.Drawing.Point(5, 5);
            this.toggle_ShowHide.Name = "toggle_ShowHide";
            this.toggle_ShowHide.Size = new System.Drawing.Size(79, 27);
            this.toggle_ShowHide.TabIndex = 1;
            this.toggle_ShowHide.Text = "tFive_Toggle1";
            this.toggle_ShowHide.Toggled = false;
            this.toggle_ShowHide.Type = TFive.TFiveToggle._Type.OnOff;
            this.toggle_ShowHide.ToggledChanged += new TFive.TFiveToggle.ToggledChangedEventHandler(this.toggle_ShowHide_ToggledChanged);
            // 
            // bt_start_stop
            // 
            this.bt_start_stop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bt_start_stop.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bt_start_stop.Image = null;
            this.bt_start_stop.Location = new System.Drawing.Point(10, 332);
            this.bt_start_stop.Name = "bt_start_stop";
            this.bt_start_stop.NoRounding = false;
            this.bt_start_stop.Size = new System.Drawing.Size(359, 50);
            this.bt_start_stop.TabIndex = 1;
            this.bt_start_stop.Text = "Start";
            this.bt_start_stop.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.gbLoop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 382);
            this.panel2.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.gbLogs);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 180);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel8.Size = new System.Drawing.Size(268, 202);
            this.panel8.TabIndex = 4;
            // 
            // gbLogs
            // 
            this.gbLogs.BackColor = System.Drawing.Color.Transparent;
            this.gbLogs.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbLogs.Controls.Add(this.logs_box);
            this.gbLogs.Curv1 = 1;
            this.gbLogs.Curv2 = 2;
            this.gbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogs.Location = new System.Drawing.Point(0, 10);
            this.gbLogs.MinimumSize = new System.Drawing.Size(136, 50);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Padding = new System.Windows.Forms.Padding(2, 25, 2, 1);
            this.gbLogs.Size = new System.Drawing.Size(268, 192);
            this.gbLogs.TabIndex = 0;
            this.gbLogs.Text = "Logs";
            // 
            // logs_box
            // 
            this.logs_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.logs_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logs_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs_box.Location = new System.Drawing.Point(2, 25);
            this.logs_box.Name = "logs_box";
            this.logs_box.ReadOnly = true;
            this.logs_box.Size = new System.Drawing.Size(264, 166);
            this.logs_box.TabIndex = 0;
            this.logs_box.Text = "";
            // 
            // gbLoop
            // 
            this.gbLoop.BackColor = System.Drawing.Color.Transparent;
            this.gbLoop.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbLoop.Controls.Add(this.txt_numDelay);
            this.gbLoop.Controls.Add(this.txt_numTimes);
            this.gbLoop.Controls.Add(this.txt_delay);
            this.gbLoop.Controls.Add(this.lbDelay);
            this.gbLoop.Controls.Add(this.tFive_Separator4);
            this.gbLoop.Controls.Add(this.lb_loopInter);
            this.gbLoop.Controls.Add(this.tFive_Separator1);
            this.gbLoop.Controls.Add(this.radio_loopNonStop);
            this.gbLoop.Controls.Add(this.radio_loop_time);
            this.gbLoop.Curv1 = 1;
            this.gbLoop.Curv2 = 2;
            this.gbLoop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLoop.Location = new System.Drawing.Point(0, 0);
            this.gbLoop.MinimumSize = new System.Drawing.Size(136, 50);
            this.gbLoop.Name = "gbLoop";
            this.gbLoop.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.gbLoop.Size = new System.Drawing.Size(268, 180);
            this.gbLoop.TabIndex = 3;
            this.gbLoop.Text = "Loop Settings";
            // 
            // txt_numDelay
            // 
            this.txt_numDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_numDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_numDelay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_numDelay.Location = new System.Drawing.Point(102, 100);
            this.txt_numDelay.MaxLength = 32767;
            this.txt_numDelay.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_numDelay.Multiline = false;
            this.txt_numDelay.Name = "txt_numDelay";
            this.txt_numDelay.ReadOnly = false;
            this.txt_numDelay.Size = new System.Drawing.Size(93, 31);
            this.txt_numDelay.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_numDelay.TabIndex = 17;
            this.txt_numDelay.Text = "0";
            this.txt_numDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_numDelay.UseSystemPasswordChar = false;
            this.txt_numDelay.TextChanged += new System.EventHandler(this.txt_numDelay_TextChanged);
            // 
            // txt_numTimes
            // 
            this.txt_numTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_numTimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_numTimes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_numTimes.Location = new System.Drawing.Point(64, 28);
            this.txt_numTimes.MaxLength = 32767;
            this.txt_numTimes.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_numTimes.Multiline = false;
            this.txt_numTimes.Name = "txt_numTimes";
            this.txt_numTimes.ReadOnly = false;
            this.txt_numTimes.Size = new System.Drawing.Size(93, 31);
            this.txt_numTimes.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_numTimes.TabIndex = 16;
            this.txt_numTimes.Text = "1";
            this.txt_numTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_numTimes.UseSystemPasswordChar = false;
            this.txt_numTimes.TextChanged += new System.EventHandler(this.txt_numTimes_TextChanged);
            // 
            // txt_delay
            // 
            this.txt_delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_delay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt_delay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_delay.Location = new System.Drawing.Point(53, 143);
            this.txt_delay.MaxLength = 32767;
            this.txt_delay.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_delay.Multiline = false;
            this.txt_delay.Name = "txt_delay";
            this.txt_delay.ReadOnly = false;
            this.txt_delay.Size = new System.Drawing.Size(93, 31);
            this.txt_delay.Style = TFive.TFiveTextBox._Num.NumberOnly;
            this.txt_delay.TabIndex = 15;
            this.txt_delay.Text = "10";
            this.txt_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_delay.UseSystemPasswordChar = false;
            this.txt_delay.TextChanged += new System.EventHandler(this.txt_delay_TextChanged);
            // 
            // lbDelay
            // 
            this.lbDelay.AutoSize = true;
            this.lbDelay.BackColor = System.Drawing.Color.Transparent;
            this.lbDelay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lbDelay.Location = new System.Drawing.Point(8, 148);
            this.lbDelay.Name = "lbDelay";
            this.lbDelay.Size = new System.Drawing.Size(223, 20);
            this.lbDelay.TabIndex = 14;
            this.lbDelay.Text = "Delay                         Millisecond";
            // 
            // tFive_Separator4
            // 
            this.tFive_Separator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Separator4.Location = new System.Drawing.Point(8, 133);
            this.tFive_Separator4.Name = "tFive_Separator4";
            this.tFive_Separator4.Size = new System.Drawing.Size(243, 10);
            this.tFive_Separator4.TabIndex = 13;
            this.tFive_Separator4.Text = "tFive_Separator4";
            // 
            // lb_loopInter
            // 
            this.lb_loopInter.AutoSize = true;
            this.lb_loopInter.BackColor = System.Drawing.Color.Transparent;
            this.lb_loopInter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lb_loopInter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lb_loopInter.Location = new System.Drawing.Point(8, 105);
            this.lb_loopInter.Name = "lb_loopInter";
            this.lb_loopInter.Size = new System.Drawing.Size(215, 20);
            this.lb_loopInter.TabIndex = 12;
            this.lb_loopInter.Text = "Loop interval                         ms";
            // 
            // tFive_Separator1
            // 
            this.tFive_Separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Separator1.Location = new System.Drawing.Point(8, 86);
            this.tFive_Separator1.Name = "tFive_Separator1";
            this.tFive_Separator1.Size = new System.Drawing.Size(243, 10);
            this.tFive_Separator1.TabIndex = 10;
            this.tFive_Separator1.Text = "tFive_Separator1";
            // 
            // radio_loopNonStop
            // 
            this.radio_loopNonStop.BackColor = System.Drawing.Color.Transparent;
            this.radio_loopNonStop.Checked = true;
            this.radio_loopNonStop.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radio_loopNonStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.radio_loopNonStop.Location = new System.Drawing.Point(8, 65);
            this.radio_loopNonStop.Name = "radio_loopNonStop";
            this.radio_loopNonStop.Size = new System.Drawing.Size(243, 15);
            this.radio_loopNonStop.TabIndex = 2;
            this.radio_loopNonStop.Text = "Loop until stop button is pressed";
            // 
            // radio_loop_time
            // 
            this.radio_loop_time.BackColor = System.Drawing.Color.Transparent;
            this.radio_loop_time.Checked = false;
            this.radio_loop_time.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radio_loop_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.radio_loop_time.Location = new System.Drawing.Point(8, 38);
            this.radio_loop_time.Name = "radio_loop_time";
            this.radio_loop_time.Size = new System.Drawing.Size(193, 15);
            this.radio_loop_time.TabIndex = 0;
            this.radio_loop_time.Text = "Loop                         times";
            this.radio_loop_time.CheckedChanged += new TFive.TFiveRadioButton.CheckedChangedEventHandler(this.radio_loop_time_CheckedChanged);
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabAbout.Controls.Add(this.tFive_TextBox1);
            this.tabAbout.Controls.Add(this.panel3);
            this.tabAbout.Location = new System.Drawing.Point(4, 34);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(643, 388);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            // 
            // tFive_TextBox1
            // 
            this.tFive_TextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFive_TextBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_TextBox1.Location = new System.Drawing.Point(389, 3);
            this.tFive_TextBox1.MaxLength = 32767;
            this.tFive_TextBox1.MinimumSize = new System.Drawing.Size(0, 31);
            this.tFive_TextBox1.Multiline = true;
            this.tFive_TextBox1.Name = "tFive_TextBox1";
            this.tFive_TextBox1.ReadOnly = true;
            this.tFive_TextBox1.Size = new System.Drawing.Size(251, 382);
            this.tFive_TextBox1.Style = TFive.TFiveTextBox._Num.TextNum;
            this.tFive_TextBox1.TabIndex = 1;
            this.tFive_TextBox1.Text = "Special Thanks to:\r\n\r\nเขียนโปรแกรมยามว่าง และ สมาชิก\r\n\r\nyck1509\r\n\r\nnd1279\r\n\r\nDorA" +
    "Em0nKiNG Team";
            this.tFive_TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tFive_TextBox1.UseSystemPasswordChar = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblLanguageAuthor);
            this.panel3.Controls.Add(this.gbSettings);
            this.panel3.Controls.Add(this.tFive_Label3);
            this.panel3.Controls.Add(this.tFive_Label2);
            this.panel3.Controls.Add(this.tFive_Separator3);
            this.panel3.Controls.Add(this.tFive_Separator2);
            this.panel3.Controls.Add(this.cb_easyList);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(15);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(15);
            this.panel3.Size = new System.Drawing.Size(386, 382);
            this.panel3.TabIndex = 0;
            // 
            // lblLanguageAuthor
            // 
            this.lblLanguageAuthor.AutoSize = true;
            this.lblLanguageAuthor.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguageAuthor.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLanguageAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lblLanguageAuthor.Location = new System.Drawing.Point(18, 198);
            this.lblLanguageAuthor.Name = "lblLanguageAuthor";
            this.lblLanguageAuthor.Size = new System.Drawing.Size(264, 20);
            this.lblLanguageAuthor.TabIndex = 3;
            this.lblLanguageAuthor.Text = "&Language Author by TFive (Developer)";
            // 
            // gbSettings
            // 
            this.gbSettings.BackColor = System.Drawing.Color.Transparent;
            this.gbSettings.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbSettings.Controls.Add(this.cb_logs);
            this.gbSettings.Controls.Add(this.comboStart);
            this.gbSettings.Controls.Add(this.lbLang);
            this.gbSettings.Controls.Add(this.cbbLanguages);
            this.gbSettings.Controls.Add(this.lbHotkey);
            this.gbSettings.Controls.Add(this.cb_topMost);
            this.gbSettings.Curv1 = 1;
            this.gbSettings.Curv2 = 1;
            this.gbSettings.Location = new System.Drawing.Point(0, 234);
            this.gbSettings.MinimumSize = new System.Drawing.Size(136, 50);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.gbSettings.Size = new System.Drawing.Size(377, 148);
            this.gbSettings.TabIndex = 7;
            this.gbSettings.Text = "Settings";
            // 
            // cb_logs
            // 
            this.cb_logs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_logs.CheckedState = false;
            this.cb_logs.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_logs.Image = null;
            this.cb_logs.Location = new System.Drawing.Point(130, 33);
            this.cb_logs.MaximumSize = new System.Drawing.Size(600, 16);
            this.cb_logs.MinimumSize = new System.Drawing.Size(16, 16);
            this.cb_logs.Name = "cb_logs";
            this.cb_logs.NoRounding = false;
            this.cb_logs.Size = new System.Drawing.Size(126, 16);
            this.cb_logs.TabIndex = 11;
            this.cb_logs.Text = "Manaul Logs";
            // 
            // comboStart
            // 
            this.comboStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.comboStart.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.comboStart.Curv = 5;
            this.comboStart.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStart.DropDownHeight = 100;
            this.comboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.comboStart.FormattingEnabled = true;
            this.comboStart.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.comboStart.IntegralHeight = false;
            this.comboStart.ItemHeight = 20;
            this.comboStart.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.comboStart.Location = new System.Drawing.Point(158, 61);
            this.comboStart.Name = "comboStart";
            this.comboStart.Size = new System.Drawing.Size(131, 26);
            this.comboStart.StartIndex = 0;
            this.comboStart.TabIndex = 10;
            // 
            // lbLang
            // 
            this.lbLang.AutoSize = true;
            this.lbLang.BackColor = System.Drawing.Color.Transparent;
            this.lbLang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbLang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lbLang.Location = new System.Drawing.Point(18, 94);
            this.lbLang.Name = "lbLang";
            this.lbLang.Size = new System.Drawing.Size(80, 20);
            this.lbLang.TabIndex = 6;
            this.lbLang.Text = "&Languages";
            // 
            // cbbLanguages
            // 
            this.cbbLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbbLanguages.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbbLanguages.Curv = 5;
            this.cbbLanguages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbLanguages.DropDownHeight = 100;
            this.cbbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanguages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbLanguages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.cbbLanguages.FormattingEnabled = true;
            this.cbbLanguages.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.cbbLanguages.IntegralHeight = false;
            this.cbbLanguages.ItemHeight = 20;
            this.cbbLanguages.Items.AddRange(new object[] {
            "English",
            "ไทย"});
            this.cbbLanguages.Location = new System.Drawing.Point(104, 93);
            this.cbbLanguages.Name = "cbbLanguages";
            this.cbbLanguages.Size = new System.Drawing.Size(184, 26);
            this.cbbLanguages.StartIndex = 0;
            this.cbbLanguages.TabIndex = 5;
            this.cbbLanguages.SelectionChangeCommitted += new System.EventHandler(this.cbbLanguages_SelectionChangeCommitted);
            // 
            // lbHotkey
            // 
            this.lbHotkey.AutoSize = true;
            this.lbHotkey.BackColor = System.Drawing.Color.Transparent;
            this.lbHotkey.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lbHotkey.Location = new System.Drawing.Point(18, 62);
            this.lbHotkey.Name = "lbHotkey";
            this.lbHotkey.Size = new System.Drawing.Size(134, 20);
            this.lbHotkey.TabIndex = 3;
            this.lbHotkey.Text = "&Start/Stop Hotkeys";
            // 
            // cb_topMost
            // 
            this.cb_topMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_topMost.CheckedState = false;
            this.cb_topMost.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_topMost.Image = null;
            this.cb_topMost.Location = new System.Drawing.Point(22, 33);
            this.cb_topMost.MaximumSize = new System.Drawing.Size(600, 16);
            this.cb_topMost.MinimumSize = new System.Drawing.Size(16, 16);
            this.cb_topMost.Name = "cb_topMost";
            this.cb_topMost.NoRounding = false;
            this.cb_topMost.Size = new System.Drawing.Size(102, 16);
            this.cb_topMost.TabIndex = 0;
            this.cb_topMost.Text = "Top Most";
            this.cb_topMost.Click += new System.EventHandler(this.cb_topMost_Click);
            // 
            // tFive_Label3
            // 
            this.tFive_Label3.AutoSize = true;
            this.tFive_Label3.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label3.Location = new System.Drawing.Point(18, 169);
            this.tFive_Label3.Name = "tFive_Label3";
            this.tFive_Label3.Size = new System.Drawing.Size(141, 20);
            this.tFive_Label3.TabIndex = 6;
            this.tFive_Label3.Text = "Devoloped by TFive";
            // 
            // tFive_Label2
            // 
            this.tFive_Label2.AutoSize = true;
            this.tFive_Label2.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tFive_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_Label2.Location = new System.Drawing.Point(18, 140);
            this.tFive_Label2.Name = "tFive_Label2";
            this.tFive_Label2.Size = new System.Drawing.Size(147, 20);
            this.tFive_Label2.TabIndex = 3;
            this.tFive_Label2.Text = "TFive Macro Project";
            // 
            // tFive_Separator3
            // 
            this.tFive_Separator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Separator3.Location = new System.Drawing.Point(0, 221);
            this.tFive_Separator3.Name = "tFive_Separator3";
            this.tFive_Separator3.Size = new System.Drawing.Size(377, 10);
            this.tFive_Separator3.TabIndex = 4;
            this.tFive_Separator3.Text = "tFive_Separator3";
            // 
            // tFive_Separator2
            // 
            this.tFive_Separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFive_Separator2.Location = new System.Drawing.Point(0, 127);
            this.tFive_Separator2.Name = "tFive_Separator2";
            this.tFive_Separator2.Size = new System.Drawing.Size(377, 10);
            this.tFive_Separator2.TabIndex = 3;
            this.tFive_Separator2.Text = "tFive_Separator2";
            // 
            // cb_easyList
            // 
            this.cb_easyList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_easyList.CheckedState = false;
            this.cb_easyList.Enabled = false;
            this.cb_easyList.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_easyList.Image = null;
            this.cb_easyList.Location = new System.Drawing.Point(201, 140);
            this.cb_easyList.MaximumSize = new System.Drawing.Size(600, 16);
            this.cb_easyList.MinimumSize = new System.Drawing.Size(16, 16);
            this.cb_easyList.Name = "cb_easyList";
            this.cb_easyList.NoRounding = false;
            this.cb_easyList.Size = new System.Drawing.Size(176, 16);
            this.cb_easyList.TabIndex = 1;
            this.cb_easyList.Text = "Open Project Easy List";
            this.cb_easyList.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lbVersion);
            this.panel4.Controls.Add(this.tFive_HeaderLabel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(15, 15);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(150, 0, 0, 0);
            this.panel4.Size = new System.Drawing.Size(356, 106);
            this.panel4.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(44, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lbVersion.Location = new System.Drawing.Point(180, 81);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(123, 20);
            this.lbVersion.TabIndex = 1;
            this.lbVersion.Text = "TFive Project v0.1";
            // 
            // tFive_HeaderLabel1
            // 
            this.tFive_HeaderLabel1.AutoSize = true;
            this.tFive_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tFive_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold);
            this.tFive_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_HeaderLabel1.Location = new System.Drawing.Point(152, 0);
            this.tFive_HeaderLabel1.Name = "tFive_HeaderLabel1";
            this.tFive_HeaderLabel1.Size = new System.Drawing.Size(182, 81);
            this.tFive_HeaderLabel1.TabIndex = 0;
            this.tFive_HeaderLabel1.Text = "TFive";
            // 
            // tFiveMenuStrip
            // 
            this.tFiveMenuStrip.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFiveMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProject,
            this.OpenProject,
            this.SaveProject,
            this.toolsToolStripMenuItem});
            this.tFiveMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.tFiveMenuStrip.MinimumSize = new System.Drawing.Size(0, 30);
            this.tFiveMenuStrip.Name = "tFiveMenuStrip";
            controlRenderer1.ColorTable = tFiveColorTable1;
            controlRenderer1.RoundedEdges = true;
            this.tFiveMenuStrip.Renderer = controlRenderer1;
            this.tFiveMenuStrip.Size = new System.Drawing.Size(691, 30);
            this.tFiveMenuStrip.TabIndex = 0;
            this.tFiveMenuStrip.Text = "tFive_MenuStrip1";
            // 
            // newProject
            // 
            this.newProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.newProject.Image = ((System.Drawing.Image)(resources.GetObject("newProject.Image")));
            this.newProject.Name = "newProject";
            this.newProject.ShortcutKeyDisplayString = "";
            this.newProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProject.Size = new System.Drawing.Size(117, 26);
            this.newProject.Text = "New Project";
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // OpenProject
            // 
            this.OpenProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.OpenProject.Image = global::TFive_Auto_Click.Properties.Resources.open;
            this.OpenProject.Name = "OpenProject";
            this.OpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenProject.Size = new System.Drawing.Size(123, 26);
            this.OpenProject.Text = "Open Project";
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // SaveProject
            // 
            this.SaveProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.SaveProject.Image = global::TFive_Auto_Click.Properties.Resources.save;
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveProject.Size = new System.Drawing.Size(118, 26);
            this.SaveProject.Text = "Save Project";
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClickToolStripMenuItem,
            this.sendKeysBGToolStripMenuItem,
            this.toolStripSeparator2,
            this.addCommandToolStripMenuItem,
            this.commendToolStripMenuItem,
            this.sleepToolStripMenuItem,
            this.toolStripSeparator5,
            this.devoloperToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.toolsToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.Tools;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(72, 26);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // addClickToolStripMenuItem
            // 
            this.addClickToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.addClickToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.script;
            this.addClickToolStripMenuItem.Name = "addClickToolStripMenuItem";
            this.addClickToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.addClickToolStripMenuItem.Text = "Add Click";
            this.addClickToolStripMenuItem.Click += new System.EventHandler(this.sleepsToolStripMenuItem_Click);
            // 
            // sendKeysBGToolStripMenuItem
            // 
            this.sendKeysBGToolStripMenuItem.Enabled = false;
            this.sendKeysBGToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.sendKeysBGToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.sendkey;
            this.sendKeysBGToolStripMenuItem.Name = "sendKeysBGToolStripMenuItem";
            this.sendKeysBGToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.sendKeysBGToolStripMenuItem.Text = "Send Keys";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // addCommandToolStripMenuItem
            // 
            this.addCommandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem,
            this.goToTrueToolStripMenuItem,
            this.goToFalseToolStripMenuItem,
            this.toolStripSeparator7,
            this.messageBoxToolStripMenuItem,
            this.toolStripSeparator1,
            this.intToolStripMenuItem,
            this.resetIntToolStripMenuItem,
            this.goToByIntToolStripMenuItem});
            this.addCommandToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.addCommandToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.command;
            this.addCommandToolStripMenuItem.Name = "addCommandToolStripMenuItem";
            this.addCommandToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.addCommandToolStripMenuItem.Text = "Add Command";
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.goToToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.skip;
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.goToToolStripMenuItem.Text = "Go To";
            this.goToToolStripMenuItem.Click += new System.EventHandler(this.goToToolStripMenuItem_Click);
            // 
            // goToTrueToolStripMenuItem
            // 
            this.goToTrueToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.goToTrueToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.skipTrue;
            this.goToTrueToolStripMenuItem.Name = "goToTrueToolStripMenuItem";
            this.goToTrueToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.goToTrueToolStripMenuItem.Text = "Go To True";
            this.goToTrueToolStripMenuItem.Click += new System.EventHandler(this.goToTrueToolStripMenuItem_Click);
            // 
            // goToFalseToolStripMenuItem
            // 
            this.goToFalseToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.goToFalseToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.skipFalse;
            this.goToFalseToolStripMenuItem.Name = "goToFalseToolStripMenuItem";
            this.goToFalseToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.goToFalseToolStripMenuItem.Text = "Go To False";
            this.goToFalseToolStripMenuItem.Click += new System.EventHandler(this.goToFalseToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(162, 6);
            // 
            // messageBoxToolStripMenuItem
            // 
            this.messageBoxToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.messageBoxToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.msg;
            this.messageBoxToolStripMenuItem.Name = "messageBoxToolStripMenuItem";
            this.messageBoxToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.messageBoxToolStripMenuItem.Text = "Message Box";
            this.messageBoxToolStripMenuItem.Click += new System.EventHandler(this.messageBoxToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // intToolStripMenuItem
            // 
            this.intToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.intToolStripMenuItem.Name = "intToolStripMenuItem";
            this.intToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.intToolStripMenuItem.Text = "Int";
            this.intToolStripMenuItem.Click += new System.EventHandler(this.intToolStripMenuItem_Click);
            // 
            // resetIntToolStripMenuItem
            // 
            this.resetIntToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.resetIntToolStripMenuItem.Name = "resetIntToolStripMenuItem";
            this.resetIntToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.resetIntToolStripMenuItem.Text = "Reset Int";
            this.resetIntToolStripMenuItem.Click += new System.EventHandler(this.resetIntToolStripMenuItem_Click);
            // 
            // goToByIntToolStripMenuItem
            // 
            this.goToByIntToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.goToByIntToolStripMenuItem.Name = "goToByIntToolStripMenuItem";
            this.goToByIntToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.goToByIntToolStripMenuItem.Text = "Go To By Int";
            this.goToByIntToolStripMenuItem.Click += new System.EventHandler(this.goToByIntToolStripMenuItem_Click);
            // 
            // commendToolStripMenuItem
            // 
            this.commendToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.commendToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.commend;
            this.commendToolStripMenuItem.Name = "commendToolStripMenuItem";
            this.commendToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.commendToolStripMenuItem.Text = "Add Comment";
            this.commendToolStripMenuItem.Click += new System.EventHandler(this.commendToolStripMenuItem_Click);
            // 
            // sleepToolStripMenuItem
            // 
            this.sleepToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.sleepToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.sleep;
            this.sleepToolStripMenuItem.Name = "sleepToolStripMenuItem";
            this.sleepToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.sleepToolStripMenuItem.Text = "Add Sleep";
            this.sleepToolStripMenuItem.Click += new System.EventHandler(this.sleepToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(176, 6);
            // 
            // devoloperToolStripMenuItem
            // 
            this.devoloperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protectCodeToolStripMenuItem,
            this.showHideToolStripMenuItem,
            this.toolStripSeparator3,
            this.registerModeToolStripMenuItem});
            this.devoloperToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.devoloperToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.deve;
            this.devoloperToolStripMenuItem.Name = "devoloperToolStripMenuItem";
            this.devoloperToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.devoloperToolStripMenuItem.Text = "Developer";
            // 
            // protectCodeToolStripMenuItem
            // 
            this.protectCodeToolStripMenuItem.CheckOnClick = true;
            this.protectCodeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.protectCodeToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.protect;
            this.protectCodeToolStripMenuItem.Name = "protectCodeToolStripMenuItem";
            this.protectCodeToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.protectCodeToolStripMenuItem.Text = "Protect Code";
            this.protectCodeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.protectCodeToolStripMenuItem_CheckedChanged);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.CheckOnClick = true;
            this.showHideToolStripMenuItem.Enabled = false;
            this.showHideToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.showHideToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.show;
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.showHideToolStripMenuItem.Text = "Show/Hide";
            this.showHideToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showHideToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(172, 6);
            // 
            // registerModeToolStripMenuItem
            // 
            this.registerModeToolStripMenuItem.Enabled = false;
            this.registerModeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.registerModeToolStripMenuItem.Image = global::TFive_Auto_Click.Properties.Resources.key;
            this.registerModeToolStripMenuItem.Name = "registerModeToolStripMenuItem";
            this.registerModeToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.registerModeToolStripMenuItem.Text = "Register Mode";
            // 
            // tm_checkHK
            // 
            this.tm_checkHK.Enabled = true;
            this.tm_checkHK.Tick += new System.EventHandler(this.tm_checkhtk_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(691, 488);
            this.Controls.Add(this.tFiveTheme);
            this.Controls.Add(this.tFiveMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(707, 527);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TFive Project";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.tFiveTheme.ResumeLayout(false);
            this.TFiveTabControl.ResumeLayout(false);
            this.tabProj.ResumeLayout(false);
            this.panel_protect.ResumeLayout(false);
            this.gbAutoClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridProcess)).EndInit();
            this.tabStart.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.gbShowHide.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.gbLogs.ResumeLayout(false);
            this.gbLoop.ResumeLayout(false);
            this.gbLoop.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tFiveMenuStrip.ResumeLayout(false);
            this.tFiveMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TFive.TFiveMenuStrip tFiveMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newProject;
        private System.Windows.Forms.ToolStripMenuItem OpenProject;
        private System.Windows.Forms.ToolStripMenuItem SaveProject;
        private TFive.TFiveTheme tFiveTheme;
        private TFive.TFiveTabControl TFiveTabControl;
        private System.Windows.Forms.TabPage tabProj;
        private TFive.TFiveGroupBox gbAutoClick;
        private System.Windows.Forms.DataGridView GridProcess;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sleepToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.ToolStripMenuItem commendToolStripMenuItem;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox logs_box;
        private System.Windows.Forms.Panel panel2;
        private TFive.TFiveGroupBox gbShowHide;
        private TFive.TFiveComboBox combo_process;
        private TFive.TFiveToggle toggle_ShowHide;
        private TFive.TFiveGroupBox gbLoop;
        private TFive.TFiveRadioButton radio_loop_time;
        private TFive.TFiveRadioButton radio_loopNonStop;
        private TFive.TFiveLabel lb_loopInter;
        private TFive.TFiveSeparator tFive_Separator1;
        private TFive.TFiveButton bt_start_stop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private TFive.TFiveHeaderLabel tFive_HeaderLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private TFive.TFiveLabel lbVersion;
        private TFive.TFiveTextBox tFive_TextBox1;
        private TFive.TFiveLabel tFive_Label3;
        private TFive.TFiveLabel tFive_Label2;
        private TFive.TFiveSeparator tFive_Separator3;
        private TFive.TFiveSeparator tFive_Separator2;
        private System.Windows.Forms.Panel panel_game;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        public System.ComponentModel.BackgroundWorker Bots_Worker;
        private TFive.TFiveGroupBox gbSettings;
        private TFive.TFiveLabel lbHotkey;
        private TFive.TFiveCheckbox cb_easyList;
        private TFive.TFiveCheckbox cb_topMost;
        private System.Windows.Forms.ToolStripMenuItem addCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem devoloperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protectCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerModeToolStripMenuItem;
        private System.Windows.Forms.Panel panel_protect;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private TFive.TFiveGroupBox gbLogs;
        private TFive.TFiveTextBox txt_delay;
        private TFive.TFiveLabel lbDelay;
        private TFive.TFiveSeparator tFive_Separator4;
        private TFive.TFiveLabel lbLang;
        private TFive.TFiveComboBox cbbLanguages;
        private TFive.TFiveTextBox txt_numDelay;
        private TFive.TFiveTextBox txt_numTimes;
        private ToolStripMenuItem showHideToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private TFive_Theme.TFiveMarquee txt_creator;
        private ToolStripMenuItem sendKeysBGToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private TFive.TFiveComboBox comboStart;
        private Timer tm_checkHK;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn process;
        private DataGridViewTextBoxColumn process_name;
        private DataGridViewTextBoxColumn posi_x;
        private DataGridViewTextBoxColumn posi_y;
        private DataGridViewTextBoxColumn check_color;
        private DataGridViewTextBoxColumn click_x;
        private DataGridViewTextBoxColumn click_y;
        private DataGridViewTextBoxColumn timesClick;
        private DataGridViewTextBoxColumn NumList;
        private DataGridViewTextBoxColumn mode;
        private ToolStripMenuItem goToToolStripMenuItem;
        private ToolStripMenuItem goToTrueToolStripMenuItem;
        private ToolStripMenuItem goToFalseToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private TFive.TFiveLabel lblLanguageAuthor;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem intToolStripMenuItem;
        private ToolStripMenuItem resetIntToolStripMenuItem;
        private ToolStripMenuItem goToByIntToolStripMenuItem;
        private TFive.TFiveCheckbox cb_logs;
    }
}