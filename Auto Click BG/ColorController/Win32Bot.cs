using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TFive_Auto_Click
{
    public class Win32Bot
    {
        
        #region DllImport

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int SendMessage(
           IntPtr hWnd,
           int Msg,
           int wParam,
           int lParam);
        public static int MakeLParam(int LoWord, int HiWord)
        {
            return (int)((HiWord << 16) | (LoWord & 0xFFFF));
        }
        [DllImport("User32.dll")]
        public static extern long SetCursorPos(int x, int y);
        [DllImport("User32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll")]


        #endregion

        #region Var

        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        public const int MOUSEEVENTF_COMMAND = 0x111;
        public const int MOUSEEVENTF_MOUSEMOVE = 0x0200;
        public const int MOUSEEVENTF_LBUTTONDOWN = 0x201;
        public const int MOUSEEVENTF_LBUTTONUP = 0x202;
        public const int MOUSEEVENTF_LBUTTONDBLCLK = 0x203;
        public const int MOUSEEVENTF_RBUTTONDOWN = 0x204;
        public const int MOUSEEVENTF_RBUTTONUP = 0x205;
        public const int MOUSEEVENTF_RBUTTONDBLCLK = 0x206;
        public const int MOUSEEVENTF_KEYDOWN = 0x100;
        public const int MOUSEEVENTF_KEYUP = 0x101;
        public const int MOUSEEVENTF_MOUSEWHEEL = 0x020A;
        public const int MOUSEEVENTF_MOUSEHWHEEL = 0x020E;
        public static int WinSizeWidth;
        public static int WinSizeHeight;
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        #endregion
        public static Size GetControlSize(IntPtr iHandle) 
        {
            Rect pRect;
            Size cSize = new Size();
            GetWindowRect(iHandle, out pRect);
            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            WinSizeWidth = cSize.Width;
            WinSizeHeight = cSize.Height;
            return cSize;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static void MouseClick(IntPtr iHandle, int Gx, int Gy, string TypeClick = "LEFT")
        {
            var p = new POINT {x = Convert.ToInt16(Gx), y = Convert.ToInt16(Gy)};
            ClientToScreen(iHandle, ref p);
            SetCursorPos(p.x, p.y);
            if (TypeClick == "LEFT")
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, p.x, p.y, 0, 0);
            else if (TypeClick == "RIGHT") mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, p.x, p.y, 0, 0);
        }
        public static void MouseMove(IntPtr iHandle, int x, int y)
        {
            POINT p = new POINT {x = Convert.ToInt16(x), y = Convert.ToInt16(y)};
            ClientToScreen(iHandle, ref p);
            SetCursorPos(p.x, p.y);
        }
        public static void ActiveWindow(IntPtr iHandle)
        {
            IntPtr h = iHandle;
            ShowWindow(h, SW_SHOW);
            SetForegroundWindow(h);
            SetFocus(h);
        }
        public static void HideApp(IntPtr iHandle)
        {
            IntPtr h = iHandle;
            ShowWindow(h, SW_HIDE);
        }
        public static void ShowAPP(IntPtr iHandle)
        {
            IntPtr h = iHandle;
            ShowWindow(h, SW_SHOW);
        }
        public static void MouseClickDragBG(IntPtr iHandle, int XStart, int YStart, int XEnd, int YEnd, int Delay)
        {
            SendMessage(iHandle, MOUSEEVENTF_LBUTTONDOWN, 0x00000001, MakeLParam(XEnd, YEnd));
            Sleep(Delay);
            SendMessage(iHandle, MOUSEEVENTF_MOUSEMOVE, 0x00000001, MakeLParam(XStart, YStart));
            Sleep(Delay);
            SendMessage(iHandle, MOUSEEVENTF_MOUSEMOVE, 0x00000001, MakeLParam(XStart,YStart));
            Sleep(Delay);
            SendMessage(iHandle, MOUSEEVENTF_LBUTTONUP, 0x00000001, MakeLParam(XEnd, YEnd));
            SendMessage(iHandle, MOUSEEVENTF_LBUTTONUP, 0x00000001, MakeLParam(XEnd, YEnd));
        }
     

        public static void ClickToBG(IntPtr iHandle, int x, int y, int clickCount = 1)
        {
            SendMessage(iHandle, MOUSEEVENTF_LBUTTONDOWN, 0x00000001, MakeLParam(x, y));
            SendMessage(iHandle, MOUSEEVENTF_LBUTTONUP, 0x00000000, MakeLParam(x, y));
        }
        public static void ClickHold(IntPtr iHandle, int x, int y, int slp)
        {
            POINT p = new POINT {x = Convert.ToInt16(x), y = Convert.ToInt16(y)};
            ClientToScreen(iHandle, ref p);
            SetCursorPos(p.x, p.y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, p.x, p.y, 0, 0);
            Sleep(slp);
            mouse_event(MOUSEEVENTF_LEFTUP, p.x, p.y, 0, 0);
        }
        public static void Sleep(int slp)
        {
            Thread.Sleep(slp);
        }

        public static void AwaitSleep(int slp)
        {
            var task = WaitMy(slp);

            task.Wait();
        }

        private static Task WaitMy(int delay)
        {
            return Task.Run(async () => await Task.Delay(delay));
        }
       
        public static void WindowMove(IntPtr iHandle, int x, int y)
        {
            GetControlSize(iHandle);
            MoveWindow(iHandle, x, y, WinSizeWidth, WinSizeHeight, true);
        }
        public static bool CheckProcess(string ProcessName)
        {
            var StatusCheck = false;
            var p = Process.GetProcessesByName(ProcessName);
            if (p.Length > 0)
            {
                StatusCheck = true;
            }
            return StatusCheck;
        } 
        public static string GetWinTitle(IntPtr iHandle)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            return GetWindowText(iHandle, Buff, nChars) > 0 ? Buff.ToString() : null;
        }
        //public static void sendKeyBG(IntPtr iHandle)
        //{
        //    PostMessage(iHandle, MOUSEEVENTF_KEYDOWN, (int)Keys.Control, 0);
        //    PostMessage(iHandle, MOUSEEVENTF_KEYDOWN, (int)Keys.A, 0);
        //    PostMessage(iHandle, MOUSEEVENTF_KEYUP, (int)Keys.Control, 0);
        //}

        public static void sendKeyBG(IntPtr iHandle, Keys key)
        {
            PostMessage(iHandle, MOUSEEVENTF_KEYDOWN, (int)key, 0);
            PostMessage(iHandle, MOUSEEVENTF_KEYUP, (int)key, 0);
        }
        public static void OpenProgram(string path)
        {
            Process.Start(path);
        }



    }
}
