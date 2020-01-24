using System;
using System.Runtime.InteropServices;

namespace TFive_Auto_Click
{
    public class GetAppName
    {
        [DllImport("User32.dll")] public static extern IntPtr FindWindow(string strClassName, string strWindowName);
        public static string APP = "";
        public static string CLASS = "";
        public static IntPtr appName;

        public void AppName()
        {
            appName = FindWindow(CLASS, APP);
        }
    }
}
