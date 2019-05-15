using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TFive_Auto_Click
{
    public class LocalizationManager
    {
        public LocalizationManager(FrmMain mainForm)
        {
            _mainForm = mainForm;
            var startupPath = Application.StartupPath;
            _langDir = startupPath + "\\lng\\";
        }

        public List<LangInfo> GetLangList()
        {
            if (!Directory.Exists(_langDir))
            {
                _mainForm.WriteOutput("Language directory (/lng) doesn't exists",Color.Red);
                return null;
            }
            var files = Directory.GetFiles(_langDir, "*.lng");
            return files.Select(text => new LangInfo {File = text, Name = IniReader.ReadStringFromIni("General", "LanguageName", text), Version = IniReader.ReadStringFromIni("General", "Version", text), RightToLeft = IniReader.ReadStringFromIni("General", "RightToLeft", text)}).ToList();
        }

        public void LoadLanguageFromFile(string lngFile)
        {
            _currentLangDict.Clear();
            var iniReader = new IniReader(lngFile);
            _currentRightToLeft = iniReader.ReadString("General", "RightToLeft");
            var sectionList = iniReader.GetSectionList();
            foreach (var text in sectionList)
            {
                var dictionary = new Dictionary<string, string>();
                var keyList = iniReader.GetKeyList(text);
                foreach (var key in keyList)
                {
                    dictionary[key] = iniReader.ReadString(text, key);
                }
                _currentLangDict[text] = dictionary;
            }
        }

        #region Old

        //public void LocalizeForm(Form _form, bool adjustRightToLeft)
        //{
        //    string name = _form.Name;
        //    foreach (object obj in _form.Controls)
        //    {
        //        Control control = (Control)obj;
        //        string key;
        //        switch (key = control.GetType().Name.ToLower())
        //        {
        //            case "label":
        //            case "checkbox":
        //            case "linklabel":
        //            case "button":
        //                TranslateControlText(control, name);
        //                break;
        //            case "tabcontrol":
        //                LocalizeChildControls(control, name);
        //                break;
        //            case "tabpage":
        //                TranslateControlText(control, name);
        //                LocalizeChildControls(control, name);
        //                break;
        //            case "groupbox":
        //                TranslateControlText(control, name);
        //                LocalizeChildControls(control, name);
        //                break;
        //        }
        //    }
        //    if (adjustRightToLeft)
        //    {
        //        adjustRightToLeftLayout(_form);
        //    }
        //}

        //private void LocalizeChildControls(Control control, string section)
        //{
        //    foreach (object obj in control.Controls)
        //    {
        //        Control control2 = (Control)obj;
        //        string key;
        //        switch (key = control2.GetType().Name.ToLower())
        //        {
        //            case "label":
        //            case "checkbox":
        //            case "linklabel":
        //            case "button":
        //                TranslateControlText(control2, section);
        //                break;
        //            case "tabcontrol":
        //                LocalizeChildControls(control2, section);
        //                break;
        //            case "tabpage":
        //                TranslateControlText(control2, section);
        //                LocalizeChildControls(control2, section);
        //                break;
        //            case "groupbox":
        //                TranslateControlText(control2, section);
        //                LocalizeChildControls(control2, section);
        //                break;
        //        }
        //    }
        //}

        #endregion
        public void LocalizeForm(Form form, bool adjustRightToLeft)
        {
            var name = form.Name;
            foreach (var obj in form.Controls)
            {
                var control = (Control)obj;
                if (control.GetType().Name == "TFiveTheme")
                {
                    TranslateControlText(control, name);
                    LocalizeChildControls(control, name);
                }
            }
            if (adjustRightToLeft)
            {
                AdjustRightToLeftLayout(form);
            }
        }

        private void LocalizeChildControls(Control control, string section)
        {
            foreach (var obj in control.Controls)
            {
                var control2 = (Control)obj;
                if (control2.GetType().Name == "TFiveLabel" || control2.GetType().Name == "TFiveTextBox" ||
                    control2.GetType().Name == "TFiveRadioButton" || control2.GetType().Name == "TFiveButton" ||
                    control2.GetType().Name == "TFiveCheckbox" || control2.GetType().Name == "TFiveHeaderLabel")
                {
                    TranslateControlText(control2, section);
                }
                else if (control2.GetType().Name == "TFiveTabControl")
                {
                    TranslateControlText(control2, section);
                    LocalizeChildControls(control2, section);
                }
                else if (control2.GetType().Name == "TabPage")
                {
                    TranslateControlText(control2, section);
                    LocalizeChildControls(control2, section);
                }
                else if (control2.GetType().Name == "Panel")
                {
                    TranslateControlText(control2, section);
                    LocalizeChildControls(control2, section);
                }
                else if (control2.GetType().Name == "TFiveGroupBox")
                {
                    TranslateControlText(control2, section);
                    LocalizeChildControls(control2, section);
                }
            }
        }

        public void LocalizeForm(Form form)
        {
            LocalizeForm(form, true);
        }

        private void AdjustRightToLeftLayout(Form form)
        {
            if (_currentRightToLeft == "true" && form.RightToLeft != RightToLeft.Yes)
            {
                form.RightToLeft = RightToLeft.Yes;
                return;
            }
            if (_currentRightToLeft != "true" && form.RightToLeft == RightToLeft.Yes)
            {
                form.RightToLeft = RightToLeft.No;
            }
        }

        private void TranslateControlText(Control control, string section)
        {
            if (_currentLangDict.ContainsKey(section) && _currentLangDict[section].ContainsKey(control.Name))
            {
                control.Text = _currentLangDict[section][control.Name];
               
            }
        }

        public string TranslateMessageInner(string section, string messageId, string def)
        {
            if (_currentLangDict.ContainsKey(section) && _currentLangDict[section].ContainsKey(messageId))
            {
                return _currentLangDict[section][messageId].Replace("\\r\\n", "\r\n");
            }
            return def.Replace("\\r\\n", "\r\n");
        }

        public string TranslateMessage(string messageId, string def)
        {
            var section = "Messages";
            return TranslateMessageInner(section, messageId, def);
        }

        public string TranslateTooltip(string messageId, string def)
        {
            var section = "Tooltips";
            return TranslateMessageInner(section, messageId, def);
        }

        public string TranslateMessageWithParams(string messageId, string def, params string[] Params)
        {
            var key = "Messages";
            if (_currentLangDict.ContainsKey(key) && _currentLangDict[key].ContainsKey(messageId))
            {
                return string.Format(_currentLangDict[key][messageId].Replace("\\r\\n", "\r\n"), Params);
            }
            _mainForm.WriteOutput(messageId + "=" + def,Color.Red);
            return string.Format(def, Params);
        }

        private readonly Dictionary<string, Dictionary<string, string>> _currentLangDict = new Dictionary<string, Dictionary<string, string>>();

        private readonly FrmMain _mainForm;

        private readonly string _langDir;

        private string _currentRightToLeft = "";
    }
}
