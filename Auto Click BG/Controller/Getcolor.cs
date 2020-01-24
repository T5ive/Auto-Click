
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TFive_Auto_Click
{
    public class GetColor
    {
        #region DllImport

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        internal static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        internal static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        internal static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        internal static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        internal static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowDC(int window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(int dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]

        #endregion

        #region Var
        public static extern int ReleaseDC(int window, int dc);
        public static int GanX;
        public static int GanY;
        public static int WinSizeWidth;
        public static int WinSizeHeight;
        public const int MOUSEEVENTF_SRC_COPY = 0x00CC0020;
        public static bool Status;
        public static bool ckStatus;
        public static string ckColor = "";

        #endregion

        public static Color GetColorAt(int hwnd, int x, int y)
        {
            GanX = x;
            GanY = y;
            var dc = GetWindowDC(hwnd);
            var a = (int)GetPixel(dc, x, y);
            ReleaseDC(hwnd, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static Size GetControlSize(IntPtr iHandle) 
        {
            Rect pRect;
            var cSize = new Size();
            GetWindowRect(iHandle, out pRect);
            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            WinSizeWidth = cSize.Width;
            WinSizeHeight = cSize.Height;
            return cSize;
        } 
        private static bool HexConverter(int PixelColor, int Shade_Variation, IntPtr iHandle)
        {
            GetControlSize(iHandle);
            Status = false;
            var rect = Rectangle.FromLTRB(0, 0, WinSizeWidth, WinSizeHeight);
            var DColor = PixelColor.ToString();
            var PixelColor1 = Convert.ToInt32(DColor);
            var Pixel_Color = Color.FromArgb(PixelColor1);
            var hdcSrc = GetDC(iHandle);
            var hdcDest = CreateCompatibleDC(hdcSrc);
            var hBitmap = CreateCompatibleBitmap(hdcSrc, rect.Width, rect.Height);
            var hOld = SelectObject(hdcDest, hBitmap);
            BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, rect.X, rect.Y, MOUSEEVENTF_SRC_COPY);
            SelectObject(hdcDest, hOld);
            DeleteDC(hdcDest);
            ReleaseDC(iHandle, hdcSrc);
            var bmp = Image.FromHbitmap(hBitmap);
            var RegionIn_BitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var Formatted_Color = new int[] { Pixel_Color.B, Pixel_Color.G, Pixel_Color.R };
            unsafe
            {
                var row = (byte*)RegionIn_BitmapData.Scan0 + GanY * RegionIn_BitmapData.Stride;
                if (row[GanX * 3] >= Formatted_Color[0] - Shade_Variation & row[GanX * 3] <= Formatted_Color[0] + Shade_Variation)//b
                {
                    if (row[GanX * 3 + 1] >= Formatted_Color[1] - Shade_Variation & row[GanX * 3 + 1] <= Formatted_Color[1] + Shade_Variation)//g
                    {
                        if (row[GanX * 3 + 2] >= Formatted_Color[2] - Shade_Variation & row[GanX * 3 + 2] <= Formatted_Color[2] + Shade_Variation)// R                           
                        {
                            Status = true;
                        }
                    }
                }
            }
            bmp.UnlockBits(RegionIn_BitmapData);
            DeleteObject(hBitmap);
            bmp.Dispose();
            return Status;
        }
        public static bool GETCOLOR(IntPtr iHandle, int x, int y, int PixelColor, int Shade_Variation)
        {
            return HexConverter(PixelColor, Shade_Variation, iHandle);
        }
        public static string GetColorString( int x, int y)
        {
            IntPtr appHandle = GetAppName.appName;
            return HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y));
        } 
        private static string HexConverterOLD(Color c)
        {
            return $"0x{c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2")}";
        } 
        public static bool GetColorFast(IntPtr iHandle, int x, int y, int PixelColorX, int Shade_Variation) 
        {
            
            var appHandle = iHandle;
            var hexStr = $"{PixelColorX:x}";
            hexStr = hexStr.ToUpper();
            if (hexStr.Length == 5)
            {
                hexStr = "0x0" + hexStr;
            }
            else
            {
                hexStr = "0x" + hexStr;
            }
            if (HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y)) == hexStr)
            {
              
                ckStatus = true;
                ckColor = HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y));
            }
            else
            {
                ckStatus = false;
                ckColor = HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y)) ;
            }
                     return ckStatus;
        }

        public static int StringColor(string color)
        {
            var ColorCut0x = color.Replace("0x", "");
            var intValue = int.Parse(ColorCut0x, System.Globalization.NumberStyles.HexNumber);
            return intValue;
        }

        public static Color GetColorToBG(string color)
        {
            var myColor = ColorTranslator.FromHtml(color);
            return myColor;
        }
    }
}

