using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TFive_Auto_Click
{
    internal class IniReader
    {
        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnString, int nSize, string lpFilename);

        [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "WritePrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
        private static extern int WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFilename);

        public IniReader(string iniPath)
        {
            Path = iniPath;
        }

        public void WriteString(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        public static string ReadStringFromIni(string section, string key, string filePath)
        {
            var text = new string(' ', 1024);
            GetPrivateProfileString(section, key, "", text, 1024, filePath);
            var array = new char[1];
            var separator = array;
            return text.Split(separator)[0];
        }

        public string ReadString(string section, string key)
        {
            var text = new string(' ', 1024);
            GetPrivateProfileString(section, key, "", text, 1024, Path);
            var array = new char[1];
            var separator = array;
            return text.Split(separator)[0];
        }

        public string ReadString(string section, string key, string def)
        {
            var text = new string(' ', 1024);
            GetPrivateProfileString(section, key, def, text, 1024, Path);
            var array = new char[1];
            var separator = array;
            return text.Split(separator)[0];
        }

        public List<string> GetSectionList()
        {
            var text = new string(' ', 65536);
            GetPrivateProfileString(null, null, null, text, 65536, Path);
            var array = new char[1];
            var separator = array;
            var list = new List<string>(text.Split(separator));
            list.RemoveRange(list.Count - 2, 2);
            return list;
        }

        public List<string> GetKeyList(string section)
        {
            var text = new string(' ', 32768);
            GetPrivateProfileString(section, null, null, text, 32768, Path);
            var array = new char[1];
            var separator = array;
            var list = new List<string>(text.Split(separator));
            list.RemoveRange(list.Count - 2, 2);
            return list;
        }

        public string Path;
    }
}
