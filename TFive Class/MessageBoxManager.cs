﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TFive_Class
{
    public class MessageBoxManager
    {
        #region Var

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

        private const int WH_CALLWNDPROCRET = 12;
        private const int WM_DESTROY = 0x0002;
        private const int WM_INITDIALOG = 0x0110;
        private const int WM_TIMER = 0x0113;
        private const int WM_USER = 0x400;
        private const int DM_GETDEFID = WM_USER + 0;

        private const int MBOK = 1;
        private const int MBCancel = 2;
        private const int MBAbort = 3;
        private const int MBRetry = 4;
        private const int MBIgnore = 5;
        private const int MBYes = 6;
        private const int MBNo = 7;

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        private static HookProc hookProc;
        private static EnumChildProc enumProc;
        [ThreadStatic]
        private static IntPtr hHook;
        [ThreadStatic]
        private static int nButton;

        /// <summary>
        /// OK text
        /// </summary>
        public static string OK = "&OK";
        /// <summary>
        /// Cancel text
        /// </summary>
        public static string Cancel = "&Cancel";
        /// <summary>
        /// Abort text
        /// </summary>
        public static string Abort = "&Abort";
        /// <summary>
        /// Retry text
        /// </summary>
        public static string Retry = "&Retry";
        /// <summary>
        /// Ignore text
        /// </summary>
        public static string Ignore = "&Ignore";
        /// <summary>
        /// Yes text
        /// </summary>
        public static string Yes = "&Yes";
        /// <summary>
        /// No text
        /// </summary>
        public static string No = "&No";

        #endregion
        #region DllImport

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        private static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLengthW", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextW", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport("user32.dll")]
        private static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetClassNameW", CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll", EntryPoint = "SetWindowTextW", CharSet = CharSet.Unicode)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        #endregion

        static MessageBoxManager()
        {
            hookProc = MessageBoxHookProc;
            enumProc = MessageBoxEnumProc;
            hHook = IntPtr.Zero;
        }

        /// <summary>
        /// Enables MessageBoxManager functionality
        /// </summary>
        /// <remarks>
        /// MessageBoxManager functionality is enabled on current thread only.
        /// Each thread that needs MessageBoxManager functionality has to call this method.
        /// </remarks>
        public static void Register()
        {
            if (hHook != IntPtr.Zero)
                throw new NotSupportedException("One hook per thread allowed.");
            //hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, hookProc, IntPtr.Zero, 13316);
        }

        /// <summary>
        /// Disables MessageBoxManager functionality
        /// </summary>
        /// <remarks>
        /// Disables MessageBoxManager functionality on current thread only.
        /// </remarks>
        public static void Unregister()
        {
            if (hHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hHook);
                hHook = IntPtr.Zero;
            }
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return CallNextHookEx(hHook, nCode, wParam, lParam);

            var msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            var hook = hHook;

            var className = new StringBuilder(10);
            if (msg.message == WM_INITDIALOG)
            {
                GetWindowTextLength(msg.hwnd);
                GetClassName(msg.hwnd, className, className.Capacity);
                if (className.ToString() == "#32770")
                {
                    nButton = 0;
                    EnumChildWindows(msg.hwnd, enumProc, IntPtr.Zero);
                    if (nButton == 1)
                    {
                        var hButton = GetDlgItem(msg.hwnd, MBCancel);
                        if (hButton != IntPtr.Zero)
                            SetWindowText(hButton, OK);
                    }
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }
        private static bool MessageBoxEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            var className = new StringBuilder(10);
            GetClassName(hWnd, className, className.Capacity);
            if (className.ToString() == "Button")
            {
                var ctlId = GetDlgCtrlID(hWnd);
                switch (ctlId)
                {
                    case MBOK:
                        SetWindowText(hWnd, OK);
                        break;
                    case MBCancel:
                        SetWindowText(hWnd, Cancel);
                        break;
                    case MBAbort:
                        SetWindowText(hWnd, Abort);
                        break;
                    case MBRetry:
                        SetWindowText(hWnd, Retry);
                        break;
                    case MBIgnore:
                        SetWindowText(hWnd, Ignore);
                        break;
                    case MBYes:
                        SetWindowText(hWnd, Yes);
                        break;
                    case MBNo:
                        SetWindowText(hWnd, No);
                        break;
                        default:
                            break;
                }
                nButton++;
            }

            return true;
        }


        public static void _Error(string msg)
        {
          MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void _Success(string msg)
        {
            MessageBox.Show(msg, @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool _Confirm(string msg)
        {
            return MessageBox.Show(msg, @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
