using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Magnifying_Glass
{
    public class MagnifyingGlass : UserControl
    {
        private int _PixelSize = 21;
        private int _PixelRange = 3;
        private bool FollowCursor = false;
        internal MovingMagnifyingGlass _DisplayForm;
        private bool _UseMovingGlass;

        public MagnifyingGlass()
            : this(true)
        {
        }

        public MagnifyingGlass(bool movingGlass)
        {
            if (movingGlass)
            {
                MovingGlass = new MovingMagnifyingGlass();
                MovingGlass.MagnifyingGlass.DisplayUpdated += MagnifyingGlass_DisplayUpdated;
                UseMovingGlass = true;
            }
            UpdateTimer.Tick += _UpdateTimer_Tick;
            CalculateSize();
        }

        #region Properties
        public int PixelSize
        {
            get => _PixelSize;
            set
            {
                var temp = value;
                if (temp < 3)
                {
                    // Minimum size
                    temp = 3;
                }
                if ((double)temp / 2 == Math.Floor((double)temp / 2))
                {
                    // Use only integers that can't be divided by 2
                    temp++;
                }
                _PixelSize = temp;
                CalculateSize();
            }
        }
        public bool UseMovingGlass
        {
            get
            {
                return _UseMovingGlass;
            }
            set
            {
                if (MovingGlass != null)
                {
                    _UseMovingGlass = value;
                }
            }
        }

        public MovingMagnifyingGlass MovingGlass { get; }

        [Browsable(false)]
        public bool IsEnabled => Visible && Enabled && !DesignMode;

        public int PixelRange
        {
            get
            {
                return _PixelRange;
            }
            set
            {
                var temp = value;
                if (temp < 1)
                {
                    // Minimum range is one pixel
                    temp = 1;
                }
                _PixelRange = temp;
                CalculateSize();
            }
        }

        public new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                // Settings will be ignored 'cause size will be calculated internal
            }
        }

        public Timer UpdateTimer { get; } = new Timer();

        public Color PixelColor
        {
            get
            {
                Bitmap bmp = null;
                try
                {
                    bmp = new Bitmap(1, 1);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(Cursor.Position, new Point(0, 0), bmp.Size);
                    }
                    return bmp.GetPixel(0, 0);
                }
                finally
                {
                    bmp?.Dispose();
                }
            }
        }
        #endregion

        #region Painting
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Only paint the background, if we're disabled or in DesignMode
            if (!IsEnabled)
            {
                base.OnPaintBackground(e);
            }
        }
        public static Color ConvertColor(Color pixelColor)
        {
            const int nThreshold = 105;
            var bgDelta = Convert.ToInt32(pixelColor.R * 0.299 + pixelColor.G * 0.587 + pixelColor.B * 0.114);
            var colorLine = 255 - bgDelta < nThreshold ? Color.Black : Color.White;
            return colorLine;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!IsEnabled)
            {
                return;
            }
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            var pos = Cursor.Position;
            var scr = Screen.PrimaryScreen.Bounds;
            var zeroPoint = new Point(0, 0);


            #region Make the screenshot
            var shot = new Rectangle(zeroPoint, new Size(Size.Width / PixelSize, Size.Height / PixelSize));
            var defaultLocation = new Point(pos.X - PixelRange, pos.Y - PixelRange);
            shot.Location = defaultLocation;
            if (shot.Location.X < 0)
            {
                shot.Size = new Size(shot.Size.Width + shot.Location.X, shot.Size.Height);
                shot.Location = new Point(0, shot.Location.Y);
            }
            else if (shot.Location.X > scr.Width)
            {
                shot.Size = new Size(shot.Location.X - scr.Width, shot.Size.Height);
            }
            if (shot.Location.Y < 0)
            {
                shot.Size = new Size(shot.Size.Width, shot.Size.Height + shot.Location.Y);
                shot.Location = new Point(shot.Location.X, 0);
            }
            else if (shot.Location.Y > scr.Height)
            {
                shot.Size = new Size(shot.Size.Width, shot.Location.Y - scr.Height);
            }
            var screenShot = new Bitmap(shot.Width, shot.Height, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(screenShot))
            {
                var makeScreenShot = !FollowCursor;
                if (makeScreenShot)
                {
                    if (MovingGlass != null)
                    {
                        makeScreenShot &= !MovingGlass.Visible;
                    }
                }
                if (makeScreenShot)
                {
                    g.CopyFromScreen(shot.Location, zeroPoint, shot.Size);
                }

            }
            #endregion

            #region Paint the screenshot scaled to the display

            var display = new Rectangle(zeroPoint, Size);
            var displaySize = new Size(shot.Width * PixelSize, shot.Height * PixelSize);
            if (defaultLocation.X < 0 || defaultLocation.X > scr.Width)
            {
                if (defaultLocation.X < 0)
                {
                    display.Location = new Point(display.Width - displaySize.Width, display.Location.Y);
                }
                display.Size = new Size(displaySize.Width, display.Size.Height);
            }
            if (defaultLocation.Y < 0 || defaultLocation.Y > scr.Height)
            {
                if (defaultLocation.Y < 0)
                {
                    display.Location = new Point(display.Location.X, display.Height - displaySize.Height);
                }
                display.Size = new Size(displaySize.Width, displaySize.Height);
            }
            if (displaySize != Size)
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(zeroPoint, Size));
            }
            e.Graphics.DrawImage(screenShot, display);
            screenShot.Dispose();
            #endregion

            #region Paint Pixel
            var xy = PixelSize * PixelRange;
            var xy2 = xy * 2;
            var colorLine = ConvertColor(PixelColor);
            e.Graphics.DrawLine(new Pen(colorLine), xy, 0, xy, xy2);
            e.Graphics.DrawLine(new Pen(colorLine), 0, xy, xy2 + 10, xy);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255, 255, 255))), new Rectangle(new Point(0, 0), new Size(xy2 + 9, xy2)));
            #endregion

        }
        #endregion

        private void CalculateSize()
        {
            var wh = PixelSize * (PixelRange * 2 + 1);
            base.Size = new Size(wh, wh);
        }

        private void _UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateTimer.Stop();
                if (IsEnabled)
                {
                    Invalidate();
                    OnDisplayUpdated();
                }
            }
            finally
            {
                UpdateTimer.Start();
            }
        }

        public delegate void DisplayUpdatedDelegate(MagnifyingGlass sender);

        public event DisplayUpdatedDelegate DisplayUpdated;

        private void OnDisplayUpdated()
        {
            DisplayUpdated?.Invoke(this);
        }

        #region Moving glass related methods


        private void MagnifyingGlass_DisplayUpdated(MagnifyingGlass sender)
        {
            Invalidate();
            OnDisplayUpdated();
        }
        #endregion
    }

    public sealed class MovingMagnifyingGlass : Form
    {
        public MovingMagnifyingGlass()
        {
            Opacity = .75;
            ShowInTaskbar = false;
            ShowIcon = false;
            FormBorderStyle = FormBorderStyle.None;
            MagnifyingGlass.PixelSize = 21;
            MagnifyingGlass.PixelRange = 3;
            MagnifyingGlass.BackColor = Color.Black;
            MagnifyingGlass.ForeColor = Color.White;
            MagnifyingGlass.UpdateTimer.Interval = 50;
            MagnifyingGlass._DisplayForm = this;
            MagnifyingGlass.BorderStyle = BorderStyle.FixedSingle;
            MagnifyingGlass.Resize += MagnifyingGlass_Resize;
            MagnifyingGlass.Location = new Point(0, 0);
            Controls.Add(MagnifyingGlass);
            Size = MagnifyingGlass.Size;
            Text = @"Magnify TFive";
        }

        private void MagnifyingGlass_Resize(object sender, EventArgs e)
        {
            Size = MagnifyingGlass.Size;
        }

        public MagnifyingGlass MagnifyingGlass { get; } = new MagnifyingGlass(false);
    }

}
