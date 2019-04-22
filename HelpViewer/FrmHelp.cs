using System;
using System.Drawing;
using System.Windows.Forms;
using Help_Viewer.Properties;

namespace HelpViewer
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();
        }

        private void FrmHelp_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = Settings.Default.Location;
                Size = Settings.Default.Size;
            }
            if (Settings.Default.Minimized)
            {
                WindowState = FormWindowState.Minimized;
                Location = Settings.Default.Location;
                Size = Settings.Default.Size;
            }
            else
            {
                Location = Settings.Default.Location;
                Size = Settings.Default.Size;
            }

        }

        private void FrmHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Settings.Default.Location = RestoreBounds.Location;
                    Settings.Default.Size = RestoreBounds.Size;
                    Settings.Default.Maximized = true;
                    Settings.Default.Minimized = false;
                    break;
                case FormWindowState.Normal:
                    Settings.Default.Location = Location;
                    Settings.Default.Size = Size;
                    Settings.Default.Maximized = false;
                    Settings.Default.Minimized = false;
                    break;
                default:
                    Settings.Default.Location = RestoreBounds.Location;
                    Settings.Default.Size = RestoreBounds.Size;
                    Settings.Default.Maximized = false;
                    Settings.Default.Minimized = true;
                    break;
            }

            Settings.Default.Save();
        }

        #region String
        private string License = "- Help Viewer\n"+
                                 "- Magnifying Glass (https://www.codeproject.com/Articles/17335/Pure-C-NET-Desktop-Color-Picker-With-Magnifying-Gl) \n" +
                                 "- TFive Theme (I have modified to look like ConfuserEx's design and Thank a lot of who the creator)\n" +
                                 "- TFive UI\n" +
                                 "- Win32 (https://code.msdn.microsoft.com/windowsapps/C-Getting-the-Windows-da1bd524) \n\n";

        private string Support = "Email: t5_@outlook.co.th\n" +
                                 "Facebook: https://www.facebook.com/TFive.T5 \n" +
                                 "Github: https://github.com/T5ive \n"+
                                 "Sorry for the support of English with Google Translate";

        #endregion

        #region Richbox

        #region Set Richbox

        /// <param name="color">Font Color</param>
        /// <param name="size">Font Size</param>
        /// <param name="Mode">0 = Regular | 1 = Bold | 2 = Italic | 3 = Strikeout | 4 = Underline </param>
        private static void AppendText(RichTextBox box, string text, Color color, int size, int Mode = 0)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            switch (Mode)
            {
                case 0:
                    box.SelectionFont = new Font(FontFamily.GenericSansSerif, size, FontStyle.Regular);
                    break;
                case 1:
                    box.SelectionFont = new Font(FontFamily.GenericSansSerif, size, FontStyle.Bold);
                    break;
                case 2:
                    box.SelectionFont = new Font(FontFamily.GenericSansSerif, size, FontStyle.Italic);
                    break;
                case 3:
                    box.SelectionFont = new Font(FontFamily.GenericSansSerif, size, FontStyle.Strikeout);
                    break;
                case 4:
                    box.SelectionFont = new Font(FontFamily.GenericSansSerif, size, FontStyle.Underline);
                    break;
            }

            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }

        /// <param name="Mode">0 = Regular | 1 = Bold | 2 = Italic | 3 = Strikeout | 4 = Underline </param>
        private void HeaderFont(string text, Color color, int size = 18, int Mode = 1)
        {
            AppendText(rb_view, text, color, size, Mode);
        }

        /// <param name="Mode">0 = Regular | 1 = Bold | 2 = Italic | 3 = Strikeout | 4 = Underline </param>
        private void NormalColorFont(string text, Color color, int size = 15, int Mode = 0)
        {
            AppendText(rb_view, text, color, size, Mode);
        }

        /// <param name="Mode">0 = Regular | 1 = Bold | 2 = Italic | 3 = Strikeout | 4 = Underline </param>
        private void NormalFont(string text, int size = 15, int Mode = 0)
        {
            AppendText(rb_view, text, Color.Black, size, Mode);
        }

        private void clean()
        {
            rb_view.Clear();
        }

        #endregion
        private void rb_view_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        #endregion
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            clean();
            rb_view.WordWrap = true;
            switch (e.Node.Text)
            {

                #region Contents

                case "Contents":
                    HeaderFont("Contents\n\n", Color.Blue);
                    NormalFont(Support);
                    NormalColorFont("\n\n\nAuto Click Project for $35", Color.Gold,16,4);
                    break;
                case "License":
                    rb_view.WordWrap = false;
                    HeaderFont("License\n\n", Color.Blue);
                    NormalColorFont("Auto Click -Copyright © TFive 2019\n", Color.RoyalBlue);
                    NormalColorFont("Free & Open-Source Software Licenses\n", Color.RoyalBlue);
                    NormalFont(License);
                    break;

                #endregion

                #region How To Use
                case "How To Use":
                    HeaderFont("Wait For Video Link", Color.Blue);
                    break;

                case "Add Command":
                    // HeaderFont("Add Command\n\n", Color.Blue);

                    HeaderFont("Skip\n", Color.Blue, 16);
                    NormalFont("Skip (number) times\n" +
                               "number in \"Color\" row\n");


                    HeaderFont("\nSkip True\n", Color.Blue, 16);
                    NormalFont("If a code before is true then skip (number) times\n" +
                               "number in \"Color\" row\n");

                    HeaderFont("\nSkip False\n", Color.Blue, 16);
                    NormalFont("If a code before is false then skip (number) times\n" +
                               "number in \"Color\" row\n");

                    HeaderFont("\nMessage Box\n", Color.Blue, 16);
                    NormalFont("Show Message Box\n");

                    break;
                case "Add Comment":
                    HeaderFont("Add your comment \n", Color.Blue);
                    NormalFont("For example\n" +
                               " - HP&MP Bar\n" +
                               " - Check Item Zone");
                    break;
                case "Add Click":
                    HeaderFont("Wait For Video Link", Color.Blue);
                    break;
                case "Check Color":
                    HeaderFont("Check Color\n\n", Color.Blue);
                    NormalFont("1. Drag the middle magnify icon to program and position you want to check the colour\n" +
                               "1.1 If you want to check the multicolour just press at \"+\"\n" +
                               "2. Drag bottom magnify icon to program and position you want to click\n" +
                               "3. Set the number of times\n"+
                               "4. Press OK");
                    break;
                case "No Color Check":
                    HeaderFont("No Color Check\n", Color.Blue);
                    NormalFont("1. Just only drag bottom magnify icon to program and position you want to click\n" +
                               "2. Set the number of times\n" +
                               "3. Press OK");
                    break;

                case "Add Sleep":
                    HeaderFont("Add Sleep\n", Color.Blue);

                    NormalFont("\"Sleep\" is mean wait for (number) milliseconds\n" +
                               "P.S.each 1000 milliseconds = 1 second");
                    break;

                    #endregion

            }
        }

        
    }
}
