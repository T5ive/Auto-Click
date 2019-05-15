using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TFive_Auto_Click.Properties;
using TFive_Class;

namespace TFive_Auto_Click
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Form Load/Close
        protected virtual void CheckFile()
        {
            if (!File.Exists("TFive Magnify.dll"))
            {
                MessageBox.Show(@"File ""TFive Magnify.dll"" is missing!!", @"TFive Auto Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!File.Exists("TFive Theme.dll"))
            {
                MessageBox.Show(@"File ""TFive Theme.dll"" is missing!!", @"TFive Auto Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!File.Exists("TFive UI.dll"))
            {
                MessageBox.Show(@"File ""TFive UI.dll"" is missing!!", @"TFive Auto Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!File.Exists("TFive Win32.dll"))
            {
                MessageBox.Show(@"File ""TFive Win32.dll"" is missing!!", @"TFive Auto Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }
        private void LoadLocation()
        {
            if (Settings.Default.Maximised)
            {
                WindowState = FormWindowState.Maximized;
                Location = Settings.Default.Location;
                Size = Settings.Default.Size;
            }
            else if (Settings.Default.Minimised)
            {
                WindowState = FormWindowState.Minimized;
                Location = Settings.Default.Location;
                Size = Settings.Default.Size;
            }
            else
            {
                if (Settings.Default.Location == new Point(0, 0))
                {
                    CenterToScreen();
                }
                else
                {
                    Location = Settings.Default.Location;
                }

                Size = Settings.Default.Size;
            }
        }
        private void CloseLocation()
        {
            Settings.Default.topMost = cb_topMost.CheckedState;
            Settings.Default.OpenEasy = cb_easyList.CheckedState;
            Settings.Default.StartKey = comboStart.SelectedIndex;
            Settings.Default.Lang = cbbLanguages.SelectedIndex;
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Settings.Default.Location = RestoreBounds.Location;
                    Settings.Default.Size = RestoreBounds.Size;
                    Settings.Default.Maximised = true;
                    Settings.Default.Minimised = false;
                    break;
                case FormWindowState.Normal:
                    Settings.Default.Location = Location;
                    Settings.Default.Size = Size;
                    Settings.Default.Maximised = false;
                    Settings.Default.Minimised = false;
                    break;
                default:
                    Settings.Default.Location = RestoreBounds.Location;
                    Settings.Default.Size = RestoreBounds.Size;
                    Settings.Default.Maximised = false;
                    Settings.Default.Minimised = true;
                    break;
            }
            Settings.Default.Save();
        }
        private void LoadSettings()
        {
            Size = new Size(Settings.Default.sizeWidth, Settings.Default.sizeHeight);
            cb_topMost.CheckedState = Settings.Default.topMost;
            cb_easyList.CheckedState = Settings.Default.OpenEasy;
            pictureBox1.Image = TFive_UI.Properties.Resources.T5___Text720;
            comboStart.SelectedIndex = Settings.Default.StartKey;
            InitLocalization();
            LoadSelectedLanguage();
            cbbLanguages.SelectedIndex = Settings.Default.Lang;
            LoadLanguage();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            CheckFile();
            CheckProject();
            _start = true;

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            LoadLocation();
            LoadSettings();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OnWindowClosing())
            {
                e.Cancel = true; // Cancel
            }

            CloseLocation();
        }

        #endregion

        #region Menu

        #region Var

        private bool _modified;
        private string _fileName = "Unnamed.t5proj";
        public bool FirstSaved;
        private bool _start;
        private int _numGrid;
        #endregion

        #region Title Name

        private void ChangeValue()
        {
            _modified = true;
            CheckProject();

            //if (GridProcess.Rows[0].Cells[0].Value.ToString() == "protect")
            //{
            //    panel_protect.Dock = DockStyle.Fill;
            //}
        }
        private void CheckProject()
        {
            Text = Title;
        }
        public string Title => $"{Path.GetFileName(_fileName)}{(_modified ? "*" : "")} - TFive {(StartStop ? ": Running" : "")}";

        #endregion


        #region New

        private void NewProjects()
        {
            if (!PromptSave())
                return;
            //  FirstSaved = false;
            _fileName = "Unnamed.t5proj";
            ResetGrid();
            ResetProtect();

            _modified = false;
            CheckProject();

        }

        private void newProject_Click(object sender, EventArgs e)
        {
            NewProjects();
        }

        #endregion

        #region Open

        //  read only FrmEasyList FrmEasy = new FrmEasyList();
        private void OpenProject_Click(object sender, EventArgs e)
        {
            if (cb_easyList.CheckedState)
            {
                //    FrmEasy.Show();
            }
            else
            {
                OpenProjects(1);
            }

        }

        public void OpenProjects(int modeOpen)
        {
            if (!PromptSave())
                return;

            string file;
            string fileName;

            if (modeOpen == 1)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "scripts";
                openFileDialog1.InitialDirectory = Directory.Exists(path) ? path : @"C:\";

                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

                file = openFileDialog1.FileName;

                if (file == null) return;
                fileName = file;
            }
            else
            {
                file = Values.PathFile;
                fileName = file;
            }

            try
            {
                ResetGrid();
                using (var bw = new BinaryReader(File.Open(file, FileMode.Open)))
                {
                    var n = bw.ReadInt32(); //column
                    var m = bw.ReadInt32(); //row
                    //Values.NumListMax = (n - 9) / 3; // 9,12,24
                    //Values.NumListMax = (n - 10) / 3;
                    Values.NumListMax = (n - 11) / 3;
                    for (var i = 0; i < m; ++i)
                    {

                        GridProcess.Rows.Add();
                        for (var j = 0; j < n; ++j)
                        {
                            //if (j == 9)
                            if (j == 10)
                            {
                                AddGridColumns(2);
                            }

                            if (bw.ReadBoolean())
                            {
                                GridProcess.Rows[i].Cells[j].Value = bw.ReadString();
                            }
                            else bw.ReadBoolean();
                        }
                    }

                    txt_delay.Text = bw.ReadString();
                    txt_numDelay.Text = bw.ReadString();
                    txt_numTimes.Text = bw.ReadString();
                    radio_loopNonStop.Checked = bw.ReadBoolean();
                    radio_loop_time.Checked = bw.ReadBoolean();
                    _protectOn = bw.ReadBoolean();
                    _passLock = bw.ReadString();
                    _numGrid = bw.ReadInt32();
                }

                //  FirstSaved = false;
                CheckProtect();
                Values.NumListMax++;
                _fileName = fileName;
                NumRow();
                Text = Path.GetFileName(_fileName) + @" - TFive";
                _modified = false;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Invalid project!", nameof(TFive), MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetGrid();
                _modified = false;
            }

        }


        #endregion

        #region Save

        public bool OnWindowClosing()
        {
            return PromptSave();
        }

        private bool SaveProjects()
        {
            string file;
            if (!_modified) return false;

            //if (FirstSaved && File.Exists(_fileName))
            if (File.Exists(_fileName))
            {
                var msgBox = MessageBox.Show(@"Do you want to save them?", @"Confirmation", MessageBoxButtons.YesNo);
                if (msgBox == DialogResult.No)
                {
                    return false;
                }
                file = _fileName; //File.Exists(_fileName).ToString();
                goto skipSave;
            }
            var path = AppDomain.CurrentDomain.BaseDirectory + "scripts";
            saveFileDialog1.InitialDirectory = Directory.Exists(path) ? path : @"C:\";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return false;
            file = saveFileDialog1.FileName;
        skipSave:
            try
            {
                using (var bw = new BinaryWriter(File.Open(file, FileMode.Create)))
                {
                    bw.Write(GridProcess.Columns.Count);
                    bw.Write(GridProcess.Rows.Count);
                    foreach (DataGridViewRow dgvR in GridProcess.Rows)
                    {
                        for (int j = 0; j < GridProcess.Columns.Count; ++j)
                        {
                            var val = dgvR.Cells[j].Value;
                            if (val == null)
                            {
                                bw.Write(false);
                                bw.Write(false);
                            }
                            else
                            {
                                bw.Write(true);
                                bw.Write(val.ToString());
                            }
                        }
                    }

                    bw.Write(txt_delay.Text);
                    bw.Write(txt_numDelay.Text);
                    bw.Write(txt_numTimes.Text);
                    bw.Write(radio_loopNonStop.Checked);
                    bw.Write(radio_loop_time.Checked);
                    bw.Write(_protectOn);
                    bw.Write(_passLock);
                    bw.Write(_numGrid);
                }

                _fileName = file;
                //FileName = saveFileDialog1.FileName;
                //saveFileDialog1.FileName = FileName;


                _modified = false;
                CheckProject();
               // FirstSaved = true;
                return true;
            }
            catch
            {
                MessageBox.Show(@"Invalid project!", nameof(TFive), MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
            SaveProjects();
        }

        private bool PromptSave()
        {
            if (!_modified)
            {
                return true;
            }
            var result = MessageBox.Show(@"The current project has unsaved changes. Do you want to save them?", @"Confirmation", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    return SaveProjects();
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                    return false;
                default:
                    return false;
            }
        }

        #endregion


        #region Tools

        #region ToolStrip

        private void sleepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.Click);
        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.Sleep);
        }
        private void commendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.Comment);
        }

        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.MessageBox);
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.Goto);
        }

        private void goToTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.GotoTrue);
        }

        private void goToFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.GotoFalse);
        }

        private void intToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.Int);
        }

        private void resetIntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.ResetInt);
        }
        private void goToByIntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScript(ModeScript.GotoInt);
        }


        #endregion

        #region Add Script

        private int _readOnly = 11;
        private enum ModeScript
        {
            TFive, //0
            Click, //1
            Sleep, //2
            Comment, //3
            Goto, //4
            GotoTrue, //5
            GotoFalse, //6
            MessageBox, //7
            Int, //8
            ResetInt, //9
            GotoInt // 10

        }

        //private void AddScript(int _Mode)
        private void AddScript(ModeScript script)
        {
            #region Old

            //switch (_Mode)
            //{
            //    case 1: // 1 Click Point - 0 Click Free
            //        Visible = false;
            //        var getColor = new FrmColorInfo();
            //        getColor.ShowDialog();
            //        Visible = true;
            //        if (Values.CloseFrom)
            //        {
            //            AddGridColumns(1);
            //            Values.CloseFrom = false;
            //            ChangeValue();
            //        }
            //        break;

            //    case 2: // Sleep
            //        Visible = false;
            //        var frm_Sleep = new FrmSleep();
            //        frm_Sleep.ShowDialog();
            //        Visible = true;
            //        if (Values.CloseFrom)
            //        {
            //            addGridProcess("Sleep", null, null, null, Values.sleep, null, null, 0, null, 2);
            //            Values.CloseFrom = false;
            //            ChangeValue();
            //        }
            //        break;
            //    case 3: // Comment
            //        addGridProcess(null, null, null, null, null, null, null, 0, null, 3);
            //        ChangeValue();
            //        break;

            //    case 4: // Skip
            //        addGridProcess("skip", null, null, null, 1, null, null, null, null, 4);
            //        ChangeValue();
            //        break;

            //    case 5: // Skip True
            //        addGridProcess("skip True", null, null, null, 1, null, null, null, null, 5);
            //        ChangeValue();
            //        break;

            //    case 6: // Skip False
            //        addGridProcess("skip False", null, null, null, 1, null, null, null, null, 6);
            //        ChangeValue();
            //        break;

            //    case 7: // Message Box
            //        addGridProcess("Message Box", "Text here", null, null, 1, null, null, null, null, 7);
            //        ChangeValue();
            //        break;
            //}

            #endregion

            switch (script)
            {
                case ModeScript.Click: // 1 Click Point - 0 Click Free
                    Visible = false;
                    using (var getColor = new FrmColorInfo())
                    {
                        getColor.ShowDialog();
                    }

                    Visible = true;
                    if (Values.CloseFrom)
                    {
                        AddGridColumns(1);
                        Values.CloseFrom = false;
                        ChangeValue();
                    }
                    break;
                case ModeScript.Sleep: // Sleep
                    Visible = false;
                    using (var frmSleep = new FrmSleep())
                    {
                        frmSleep.ShowDialog();
                    }

                    Visible = true;
                    if (Values.CloseFrom)
                    {
                        AddGridProcess("Sleep", null, null, null, Values.sleep, null, null, null, null, 2);
                        Values.CloseFrom = false;
                        ChangeValue();
                    }
                    break;
                case ModeScript.Comment: // Comment
                    AddGridProcess(null, null, null, null, null, null, null, null, null, 3);
                    ChangeValue();
                    break;

                case ModeScript.Goto: // Goto
                    AddGridProcess("Go to", null, null, null, 1, null, null, null, null, 4);
                    ChangeValue();
                    break;

                case ModeScript.GotoTrue: // GotoTrue
                    AddGridProcess("Go to True", null, null, null, 1, null, null, null, null, 5);
                    ChangeValue();
                    break;

                case ModeScript.GotoFalse: // GotoFalse
                    AddGridProcess("Go to False", null, null, null, 1, null, null, null, null, 6);
                    ChangeValue();
                    break;

                case ModeScript.MessageBox: // Message Box
                    AddGridProcess("Message Box", "Text here", null, null, 1, null, null, null, null, 7);
                    ChangeValue();
                    break;
                case ModeScript.Int: // New Int
                    AddGridProcess("New Int", null, null, null, 0, null, null, null, null, 8);
                    ChangeValue();
                    break;
                case ModeScript.ResetInt: // Reset Int
                    AddGridProcess("Message Box", null, null, null, 0, null, null, null, null, 9);
                    ChangeValue();
                    break;
                case ModeScript.GotoInt: // Goto
                    AddGridProcess("Go to by Int", null, null, null, 1, null, null, null, null, 10);
                    ChangeValue();
                    break;

            }

            NumRow();
        }
        private void AddGridProcess(object processName, object targetTitle, object colorX, object colorY, object color, object clickX, object clickY, object click, object point, object mode)
        {
            GridProcess.Rows.Add(_numGrid, processName, targetTitle, colorX, colorY, color, clickX, clickY, click, point, mode);
            _numGrid += 1;
        }
        private void ResetGrid()
        {
            GridProcess.Rows.Clear();
            for (int i = 2; i <= Values.NumListMax; i++)
            {
                GridProcess.Columns.Remove("color_x" + i);
                GridProcess.Columns.Remove("color_y" + i);
                GridProcess.Columns.Remove("color_ful" + i);

            }
            Values.NumListMax = 0;
            Values.NumListCurrent = 1;
            Values.NumListColor = 0;

            radio_loopNonStop.Checked = true;
            txt_numDelay.Text = @"0";
            txt_delay.Text = @"10";
            txt_numTimes.Text = @"1";
        }

        private void AddGridColumns(int num)
        {

            switch (num)
            {
                case 1: // Click Add
                    {
                        while (Values.NumListCurrent < Values.NumListColor)
                        {
                            GridProcess.Columns.Add("color_x" + (Values.NumListCurrent + 1), "Color X" + (Values.NumListCurrent + 1));
                            SetReadOnly();
                            GridProcess.Columns.Add("color_y" + (Values.NumListCurrent + 1), "Color Y" + (Values.NumListCurrent + 1));
                            SetReadOnly();
                            GridProcess.Columns.Add("color_ful" + (Values.NumListCurrent + 1), "Color " + (Values.NumListCurrent + 1));
                            SetReadOnly();
                            Values.NumListCurrent++;

                        }
                        AddGridRows(Values.NumListColor);
                        break;
                    }
                case 2: // Load
                    while (Values.NumListCurrent - 1 < Values.NumListMax)
                    {
                        GridProcess.Columns.Add("color_x" + (Values.NumListCurrent + 1), "Color X" + (Values.NumListCurrent + 1));
                        SetReadOnly();
                        GridProcess.Columns.Add("color_y" + (Values.NumListCurrent + 1), "Color Y" + (Values.NumListCurrent + 1));
                        SetReadOnly();
                        GridProcess.Columns.Add("color_ful" + (Values.NumListCurrent + 1), "Color " + (Values.NumListCurrent + 1));
                        SetReadOnly();

                        Values.NumListCurrent++;
                    }
                    break;
                default:

                    break;
            }
        }


        private void SetReadOnly()
        {
            GridProcess.Columns[_readOnly].ReadOnly = true;
            _readOnly++;
        }
        private void NumRow()
        {
            foreach (DataGridViewRow row in GridProcess.Rows)
            {
                row.HeaderCell.Value = $"{row.Index + 1}";
            }
        }
        private void AddGridRows(int num)
        {

            var index = GridProcess.Rows.Add();
            GridProcess.Rows[index].Cells[0].Value = _numGrid;
            _numGrid += 1;
            GridProcess.Rows[index].Cells[1].Value = Values.ProcessName;
            GridProcess.Rows[index].Cells[2].Value = Values.TitleName;
            GridProcess.Rows[index].Cells[3].Value = Values.CheckX;
            GridProcess.Rows[index].Cells[4].Value = Values.CheckY;
            GridProcess.Rows[index].Cells[5].Value = Values.Color;
            GridProcess.Rows[index].Cells[6].Value = Values.ClickX;
            GridProcess.Rows[index].Cells[7].Value = Values.ClickY;
            GridProcess.Rows[index].Cells[8].Value = Values.ClickTimes;
            GridProcess.Rows[index].Cells[9].Value = Values.NumListColor;

            GridProcess.Rows[index].Cells[10].Value = Values.Mode; // New

            //GridProcess.Rows[index].Cells[0].Value = Values.ProcessName;
            //GridProcess.Rows[index].Cells[1].Value = Values.TitleName;
            //GridProcess.Rows[index].Cells[2].Value = Values.CheckX;
            //GridProcess.Rows[index].Cells[3].Value = Values.CheckY;
            //GridProcess.Rows[index].Cells[4].Value = Values.Color;
            //GridProcess.Rows[index].Cells[5].Value = Values.ClickX;
            //GridProcess.Rows[index].Cells[6].Value = Values.ClickY;
            //GridProcess.Rows[index].Cells[7].Value = Values.ClickTimes;
            //GridProcess.Rows[index].Cells[8].Value = Values.NumListColor;

            //GridProcess.Rows[index].Cells[9].Value = Values.Mode; // New

            //NumRow();

            var k = 0;
            var j = 1;
            for (var i = 1; i <= (num - 1) * 3; i++) // i = Cells, num = NumListColor
            {

                var array = Values.ListColorString[j].Split(new[]
                {
                        ","
                    }, StringSplitOptions.RemoveEmptyEntries);

                //GridProcess.Rows[index].Cells[i + 8].Value = array[k];
                //GridProcess.Rows[index].Cells[i + 9].Value = array[k];
                GridProcess.Rows[index].Cells[i + 10].Value = array[k];

                k++;
                if (k > 2)
                {
                    k = 0;

                    if (j < num - 1)
                    {
                        j++;
                    }
                }
            }
        }

        #endregion


        #region Develope

        private bool _protectOn;
        private string _passOriginal = "";
        private string _passLock = "";
        private string _passUnlock = "";
        private string _creator = nameof(TFive);
        private void ResetProtect()
        {
            _protectOn = false;
            CheckProtect();
        }
        private void CheckProtect()
        {
            txt_creator.Text = _creator;
            if (_protectOn)
            {
                showHideToolStripMenuItem.Checked = true;
                protectCodeToolStripMenuItem.Enabled = false;
                //protectCodeToolStripMenuItem.Checked = true;
                showHideToolStripMenuItem.Enabled = true;
            }
            else
            {
                protectCodeToolStripMenuItem.Checked = false;
                protectCodeToolStripMenuItem.Enabled = true;
                showHideToolStripMenuItem.Checked = false;
                showHideToolStripMenuItem.Enabled = false;
            }
        }

        private void protectCodeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (protectCodeToolStripMenuItem.Checked)
            {

                _passOriginal = TFiveInputBox.Show("Input Password '8' Keys", 8);

                if (string.IsNullOrWhiteSpace(_passOriginal) || _passOriginal.Length < 8)
                {
                    protectCodeToolStripMenuItem.Checked = false;
                    return;
                }

                _creator = TFiveInputBox.Show("Input Your Name (Creator/Credit)");
                if (string.IsNullOrWhiteSpace(_creator))
                {
                    _creator = "T" + "Five";
                }

                TFiveSecurity.PasswordNeed8 = _passOriginal;
                _passLock = TFiveSecurity.EncryptString(_passOriginal);
                _protectOn = true;
                showHideToolStripMenuItem.Enabled = true;
                ChangeValue();

                CheckProtect();
            }
        }

        private void showHideToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (showHideToolStripMenuItem.Checked) // Show
            {
                panel_protect.Dock = DockStyle.Fill;
                panel_protect.Visible = true;
            }
            else // Hide
            {
                _passUnlock = TFiveInputBox.Show("Input Password '8' Keys", 8);

                if (string.IsNullOrWhiteSpace(_passUnlock) || _passUnlock.Length < 8)
                {
                    showHideToolStripMenuItem.Checked = true;
                    return;
                }

                TFiveSecurity.PasswordNeed8 = _passUnlock;
                _passUnlock = TFiveSecurity.EncryptString(_passUnlock);
                if (_passUnlock == _passLock)
                {
                    panel_protect.Visible = false;
                }
                else
                {
                    showHideToolStripMenuItem.Checked = true;
                }


            }
        }

        #endregion

        #endregion


        #endregion

        #region Tab Control

        #region Project

        #region DataGrid

        private static void CopyDataGridView(DataGridView dgvOrg)
        {
            using (var dgvCopy = new DataGridView())
            {
                try
                {
                    if (dgvCopy.Columns.Count == 0)
                    {
                        foreach (DataGridViewColumn dgvc in dgvOrg.Columns)
                        {
                            dgvCopy.Columns.Add(dgvc.Clone() as DataGridViewColumn ??
                                                throw new InvalidOperationException());
                        }
                    }

                    for (int i = 0; i < dgvOrg.Rows.Count; i++)
                    {
                        var row = (DataGridViewRow)dgvOrg.Rows[i].Clone();
                        var intColIndex = 0;
                        foreach (DataGridViewCell cell in dgvOrg.Rows[i].Cells)
                        {
                            row.Cells[intColIndex].Value = cell.Value;
                            intColIndex++;
                        }

                        dgvCopy.Rows.Add(row);
                    }

                    dgvCopy.AllowUserToAddRows = false;
                    dgvCopy.Refresh();

                }
                catch
                {
                    throw;
                }
            }
        }
        private void GridProcess_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_start)
            {
                ChangeValue();
            }

        }
#pragma warning disable CC0091 // Use static method
        private void GridProcess_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
#pragma warning restore CC0091 // Use static method
        {
            if (e.Column.Index != 0)
            {
                return;
            }

            try
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
            catch (Exception)
            {
                throw;
            }


        }
        private void GridProcess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey && e.KeyCode == Keys.C)
            {
                CopyDataGridView(GridProcess);
            }

            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey && e.KeyCode == Keys.V)
            {

            }

            if (e.KeyCode != Keys.Delete) return;
            if (MessageBox.Show(@"Are you sure to delete  " + (GridProcess.CurrentCell.RowIndex + 1) + @" ? ",
                    @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GridProcess.Rows.RemoveAt(GridProcess.CurrentCell.RowIndex);
                ChangeValue();
            }
        }
        private void GridProcess_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                return;
            }

            //if (e.ColumnIndex == 0)
            //{
            try
            {
                GridProcess.Sort(GridProcess.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception)
            {
                throw;
            }

            //}
        }


        #endregion

        #endregion

        #region Start

        #region Logs

        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }

        private string _lastOutPut;

        private void TextToLogs(string s, Color c)
        {
            if (s.Equals(_lastOutPut)) return;
            _lastOutPut = s;
            Invoke(new MethodInvoker(delegate
            {
                AppendText(logs_box, s, c);
            }));
        }
        public void WriteOutput(string s, Color c)
        {
            Invoke(new MethodInvoker(delegate
            {
                TextToLogs(string.Concat(
                        "[ ",
                        //DateTime.Now.ToString("h:mm:ss"),
                        DateTime.Now.ToString("h:mm:ss"),
                        " ]  ",
                        s,
                        "\n"),
                    c);
            }));

        }

        #endregion

        #region Bot

        #region Var
        [DllImport("user32.dll")] public static extern bool GetAsyncKeyState(Keys vKey);
        private int TimeClick = 1;
        public static IntPtr iHandle;
        readonly GetAppName GetApp = new GetAppName();
        private bool statusTF;
        private bool StartStop;

        #endregion

        #region SetUp


        private void bt_start_Click(object sender, EventArgs e)
        {
            StartBot();
        }
        private void StartBot()
        {
            bt_start_stop.Text = bt_start_stop.Text.EndsWith("Stop") ? "Start" : "Stop";
            try
            {
                switch (bt_start_stop.Text)
                {
                    case "Stop":

                        WriteOutput("Start Bot", Color.DeepSkyBlue);
                        Bots_Worker.RunWorkerAsync();
                        StartStop = true;
                        gbLoop.Enabled = false;
                        tFiveMenuStrip.Enabled = false;
                        gbAutoClick.Enabled = false;
                        break;
                    case "Start":
                        TimeClick = 1;
                        Bots_Worker.CancelAsync();
                        StartStop = false;
                        gbLoop.Enabled = true;
                        tFiveMenuStrip.Enabled = true;
                        gbAutoClick.Enabled = true;
                        WriteOutput("Stop Bot", Color.MidnightBlue);
                        break;
                }

                CheckProject();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private int _numDelay;
        private int _numTimes;
        private void Bots_Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!Bots_Worker.CancellationPending)
            {
                try
                {
                    _numDelay = int.Parse(txt_numDelay.Text);
                }
                catch (Exception)
                {
                    _numDelay = 0;
                }

                try
                {
                    _numTimes = int.Parse(txt_numTimes.Text);
                }
                catch (Exception)
                {
                    _numTimes = 1;
                }

                Win32Bot.AwaitSleep(_numDelay);
                if (radio_loop_time.Checked)
                {
                    while (TimeClick <= _numTimes)
                    {
                        WriteOutput("Round: " + TimeClick, Color.DarkOrange);
                        SetupBots(true);
                        TimeClick++;
                    }
                    StartBot();
                    WriteOutput("Finish", Color.DarkRed);
                }
                else if (radio_loopNonStop.Checked)
                {
                    SetupBots(true);
                }
            }
            SetupBots(false);

        }
        private void GetiHandle()
        {
            GetApp.AppName();
            iHandle = GetAppName.appName;
        }

        #endregion

        #region Function
        private void SetupBots(bool status)
        {

            for (int i = 0; i <= GridProcess.Rows.Count - 1; i++)
            {
                if (status)
                {
                    #region Var

                    var _Mode = int.Parse(GridProcess.Rows[i].Cells[10].Value.ToString());
                    int skip;
                    var clickX = 0;
                    var clickY = 0;
                    var clickTimes = 0;
                    var point = 0;

                    var colorX1 = 0;
                    var colorY1 = 0;
                    var color1 = 0;

                    string manualLogs;
                    #endregion

                    #region Set Value For Click

                    if (_Mode == 0 || _Mode == 1)
                    {
                        #region AddiHandle

                        string addiHandle;
                        try
                        {
                            addiHandle = GridProcess.Rows[i].Cells[2].Value.ToString();
                        }
                        catch (Exception)
                        {
                            addiHandle = "Error!!";
                        }

                        if (addiHandle != "Error!!")
                        {
                            var split = GridProcess.Rows[i].Cells[2].Value.ToString()
                                .Split(new[] { " | " }, StringSplitOptions.None);
                            GetAppName.APP = split[0];
                            GetAppName.CLASS = split[1];
                            GetiHandle();

                        }

                        #endregion

                        #region Set ClickXY, Times

                        try
                        {
                            clickX = int.Parse(GridProcess.Rows[i].Cells[6].Value.ToString());
                            clickY = int.Parse(GridProcess.Rows[i].Cells[7].Value.ToString());
                            clickTimes = int.Parse(GridProcess.Rows[i].Cells[8].Value.ToString());
                        }
                        catch (Exception)
                        {
                            clickX = 0;
                            clickY = 0;
                            clickTimes = 0;
                        }

                        #endregion

                        #region Set Point

                        try
                        {
                            point = int.Parse(GridProcess.Rows[i].Cells[9].Value.ToString());
                        }
                        catch (Exception)
                        {
                            point = 0;
                        }


                        #endregion

                        #region SetXY Color

                        try
                        {
                            colorX1 = int.Parse(GridProcess.Rows[i].Cells[3].Value.ToString());
                            colorY1 = int.Parse(GridProcess.Rows[i].Cells[4].Value.ToString());
                            color1 = GetColor.StringColor(GridProcess.Rows[i].Cells[5].Value.ToString());
                        }
                        catch (Exception)
                        {
                            colorX1 = 0;
                            colorY1 = 0;
                            color1 = 0;
                        }

                        #endregion

                    }


                    #endregion

                    #region SetLogs
                    
                        manualLogs = GridProcess.Rows[i].Cells[1].Value.ToString();

                    #endregion


                    switch (_Mode)
                    {
                        case 0:

                            #region Click Free

                            if (_Mode == 0) // Point == 0
                            {
                                GridProcess.Rows[i].Selected = true;
                                Win32Bot.ClickToBG(iHandle, clickX, clickY, clickTimes);
                                WriteOutput("Free Click : " + clickY + ", " + clickY, Color.Gold);

                                if (cb_logs.CheckedState)
                                {
                                    WriteOutput(manualLogs, Color.Gold);
                                }
                            }

                            break;

                        #endregion

                        case 1:

                            #region Click Color

                            #region Color = 1

                            if (point == 1)
                            {
                                if (GetColor.GetColorFast(iHandle, colorX1, colorY1, color1, 4))
                                {
                                    // GridProcess.Rows[i].Selected = true;
                                    Win32Bot.ClickToBG(iHandle, clickX, clickY, clickTimes);
                                    WriteOutput("Color Click : " + clickY + ", " + clickY, Color.Goldenrod);
                                    if (cb_logs.CheckedState)
                                    {
                                        WriteOutput(manualLogs, Color.Goldenrod);
                                    }
                                    statusTF = true;
                                }
                                else
                                {
                                    statusTF = false;

                                }
                            }

                            #endregion

                            #region Color > 1

                            if (point > 1)
                            {
                                var countTrue = 0;

                                if (GetColor.GetColorFast(iHandle, colorX1, colorY1, color1, 4))
                                {
                                    countTrue += 1;
                                }

                                for (var j = 0; j < point - 1; j++)
                                {
                                    var numInt = j * 3;
                                    var numX = 10 + numInt;
                                    var numY = 11 + numInt;
                                    var numColorX = 12 + numInt;

                                    #region SetXY Color

                                    int colorX_X;
                                    int colorY_X;
                                    int color_X;

                                    try
                                    {
                                        colorX_X = int.Parse(GridProcess.Rows[i].Cells[numX].Value.ToString());
                                        colorY_X = int.Parse(GridProcess.Rows[i].Cells[numY].Value.ToString());
                                        color_X = GetColor.StringColor(GridProcess.Rows[i].Cells[numColorX].Value
                                            .ToString());
                                    }
                                    catch (Exception)
                                    {
                                        colorX_X = 0;
                                        colorY_X = 0;
                                        color_X = 0;
                                    }

                                    #endregion

                                    if (GetColor.GetColorFast(iHandle, colorX_X, colorY_X, color_X, 4))
                                    {
                                        countTrue += 1;
                                    }
                                    else
                                    {
                                        countTrue = 0;
                                    }

                                }

                                if (countTrue == point)
                                {
                                    GridProcess.Rows[i].Selected = true;
                                    Win32Bot.ClickToBG(iHandle, clickX, clickY, clickTimes);
                                    WriteOutput("Color Click : " + clickY + ", " + clickY, Color.Goldenrod);
                                    if (cb_logs.CheckedState)
                                    {
                                        WriteOutput(manualLogs, Color.Goldenrod);
                                    }
                                    statusTF = true;
                                }
                                else
                                {
                                    statusTF = false;
                                }
                            }

                            #endregion

                            break;

                        #endregion

                        case 2:

                            #region Sleep

                            int sleep;
                            try
                            {
                                sleep = int.Parse(GridProcess.Rows[i].Cells[5].Value.ToString()); // Color
                            }
                            catch (Exception)
                            {
                                sleep = 0;
                            }

                            if (sleep == 0) continue;
                            WriteOutput("Sleep: " + sleep, Color.YellowGreen);
                            if (cb_logs.CheckedState)
                            {
                                WriteOutput(manualLogs, Color.YellowGreen);
                            }
                            Win32Bot.AwaitSleep(sleep);
                            break;

                        #endregion

                        case 4:

                            #region Goto

                            skip = int.Parse(GridProcess.Rows[i].Cells[5].Value.ToString());
                            if (skip > GridProcess.Rows.Count - 1)
                            {
                                break;
                            }

                            i = skip;
                            break;

                        #endregion

                        case 5:

                            #region Goto True

                            skip = int.Parse(GridProcess.Rows[i].Cells[5].Value.ToString());
                            if (skip > GridProcess.Rows.Count - 1)
                            {
                                break;
                            }

                            if (statusTF)
                            {
                                statusTF = false;
                                i = skip;
                            }

                            break;

                        #endregion

                        case 6:

                            #region Goto False

                            skip = int.Parse(GridProcess.Rows[i].Cells[5].Value.ToString());
                            if (skip > GridProcess.Rows.Count - 1)
                            {
                                break;
                            }

                            if (!statusTF)
                            {
                                i = skip;
                            }

                            break;

                        #endregion

                        case 7:

                            #region MessageBox

                            MessageBox.Show(GridProcess.Rows[i].Cells[1].Value.ToString());
                            break;

                            #endregion

                    }

                    #region Delay

                    try
                    {
                        Win32Bot.AwaitSleep(int.Parse(txt_delay.Text));
                    }
                    catch (Exception)
                    {
                        txt_delay.Text = @"10";
                        Win32Bot.AwaitSleep(10);
                    }

                    #endregion

                }
                else
                {
                    break;
                }
            }


        }
        #endregion

        #endregion

        #region Get Title Processbox

        private string _title;
        // private string processEXE;
        private void combo_process_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var split = combo_process.SelectedItem.ToString().Split(new[] { " | " }, StringSplitOptions.None);
            //     processEXE = split[0];
            _title = split[1]; //combo_process.SelectedItem.ToString().Remove(0, combo_process.SelectedItem.ToString().IndexOf("|", StringComparison.Ordinal) + 2);

        }
        private void combo_process_Click(object sender, EventArgs e)
        {
            combo_process.Items.Clear();
            ProcessList();
        }
        private void ProcessList()
        {
            var processList = Process.GetProcesses();

            foreach (var Process in processList)
            {
                if (!string.IsNullOrEmpty(Process.MainWindowTitle))
                {
                    combo_process.Items.Add(Process.ProcessName + ".exe" + " | " + Process.MainWindowTitle);
                }
            }
        }

        #endregion Get Title Processbox

        #region Setting Value
        private void txt_delay_TextChanged(object sender, EventArgs e)
        {
            ChangeValue();
        }

#pragma warning disable CC0057 // Unused parameters
        private void radio_loop_time_CheckedChanged(object sender)
#pragma warning restore CC0057 // Unused parameters
        {
            ChangeValue();
        }

        private void txt_numTimes_TextChanged(object sender, EventArgs e)
        {
            ChangeValue();
        }

        private void txt_numDelay_TextChanged(object sender, EventArgs e)
        {
            ChangeValue();
        }
        #endregion

        #region Show/Hide

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private Process _gameProcess;
        private static Size _sizeDefault;
        public static Rectangle DefaultRect;
        public static Point BorderPoint = new Point(10, 30);
        public static Size BorderSize = new Size(BorderPoint.X * 2, BorderPoint.Y + 10);


        public static Process GetProcessByWindowTitle(string windowTitle)
        {
            var processList = Process.GetProcesses();
            foreach (var process in processList)
            {
                if (process.MainWindowTitle == windowTitle)
                    return process;
            }
            return null;
        }

        private void toggle_ShowHide_ToggledChanged()
        {
            try
            {
                if (toggle_ShowHide.Toggled)
                {
                    _gameProcess = GetProcessByWindowTitle(_title);
                    _sizeDefault = Win32Bot.GetControlSize(_gameProcess.MainWindowHandle);
                    DefaultRect = new Rectangle(Screen.PrimaryScreen.Bounds.Width / 2 - _sizeDefault.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - _sizeDefault.Height / 2, _sizeDefault.Width, _sizeDefault.Height);

                    if (_gameProcess == null) return;
                    SetParent(_gameProcess.MainWindowHandle, panel_game.Handle);
                    MoveWindow(_gameProcess.MainWindowHandle, -BorderPoint.X, -BorderPoint.Y, panel_game.Width + BorderSize.Width, panel_game.Height + BorderSize.Height, true);
                }
                else
                {
                    if (_gameProcess == null) return;
                    SetParent(_gameProcess.MainWindowHandle, IntPtr.Zero);
                    MoveWindow(_gameProcess.MainWindowHandle, DefaultRect.X, DefaultRect.Y, DefaultRect.Width, DefaultRect.Height, true);


                }
            }
            catch (Exception)
            {
                toggle_ShowHide.Toggled = false;
                if (!toggle_ShowHide.Toggled)
                {
                    WriteOutput("Error", Color.Red);
                }
            }

        }

        #endregion

        #endregion

        #region About
        private void cb_topMost_Click(object sender, EventArgs e)
        {
            TopMost = cb_topMost.CheckedState;
        }
        private void tm_checkhtk_Tick(object sender, EventArgs e)
        {
            var startKey = (Keys)Enum.Parse(typeof(Keys), comboStart.SelectedItem.ToString());
            if (GetAsyncKeyState(startKey))
                StartBot();
        }

        #region Languaged Manager

        private void InitLocalization()
        {
            LclzManager = new LocalizationManager(this);
            cbbLanguages.DataSource = LclzManager.GetLangList();
            if (cbbLanguages.Items.Count == 0)
            {
                cbbLanguages.Enabled = false;
            }
        }

        public LocalizationManager LclzManager;
        private void cbbLanguages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            LoadSelectedLanguage();
            LclzManager.LocalizeForm(this);
            LocalizeSpecialCases();
        }
        public void LoadSelectedLanguage()
        {
            if (cbbLanguages.SelectedItem == null)
            {
                return;
            }
            LclzManager.LoadLanguageFromFile(((LangInfo)cbbLanguages.SelectedItem).File);
        }

        private void LocalizeSpecialCases()
        {
            newProject.Text = LclzManager.TranslateMessage("NewProject", "New Project");
            OpenProject.Text = LclzManager.TranslateMessage(nameof(OpenProject), "Open Project");
            SaveProject.Text = LclzManager.TranslateMessage(nameof(SaveProject), "Save Project");
            toolsToolStripMenuItem.Text = LclzManager.TranslateMessage("toolsMenu", "Tools");
            //helpToolStripMenuItem.Text = LclzManager.TranslateMessage("help", "Help");

            //backgroundClickToolStripMenuItem.Text = LclzManager.TranslateMessage("BackgroundZone", "- BackgroundZone -");
            addClickToolStripMenuItem.Text = LclzManager.TranslateMessage("AddClick", "Add Click");
            sendKeysBGToolStripMenuItem.Text = LclzManager.TranslateMessage("SendKeys", "Send Keys");
            //functionToolStripMenuItem.Text = LclzManager.TranslateMessage("FunctionZone", " - FunctionZone -");
            addCommandToolStripMenuItem.Text = LclzManager.TranslateMessage("AddCommand", "AddCommand");
            goToToolStripMenuItem.Text = LclzManager.TranslateMessage("Goto", "Go To");
            goToTrueToolStripMenuItem.Text = LclzManager.TranslateMessage("GotoTure", "Go To True");
            goToFalseToolStripMenuItem.Text = LclzManager.TranslateMessage("GotoFalse", "Go To False");
            messageBoxToolStripMenuItem.Text = LclzManager.TranslateMessage("Messagebox", "Message Box");
            commendToolStripMenuItem.Text = LclzManager.TranslateMessage("AddComment", "Add Comment:");
            sleepToolStripMenuItem.Text = LclzManager.TranslateMessage("AddSleep", "Add Sleep");
            //developerZoneToolStripMenuItem.Text = LclzManager.TranslateMessage("DeveloperZone", "- Developer Zone -");
            devoloperToolStripMenuItem.Text = LclzManager.TranslateMessage("Developer", "Developer");
            protectCodeToolStripMenuItem.Text = LclzManager.TranslateMessage("ProtectCode", "Protect Code");
            showHideToolStripMenuItem.Text = LclzManager.TranslateMessage("ShowHide", "Show/Hide");
            registerModeToolStripMenuItem.Text = LclzManager.TranslateMessage("RegisterMode", "Register Mode");
        }




        #endregion

        #endregion

        #endregion

       
    }
}
