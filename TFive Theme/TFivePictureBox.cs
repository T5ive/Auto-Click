using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace TFive_Theme
{
    public enum DisplayMode { Normal, Fill, Center, Stretch, Zoomable }

   public class TFivePictureBox : Control
    {
        private DisplayMode _mode = DisplayMode.Center;
        private BufferedGraphics _bufGraphics;
        private readonly BufferedGraphicsContext _bufContext = BufferedGraphicsManager.Current;
        private RectangleF _imageRect;
        private Point _lastPos;
        private Image _image;
        private Size _lastSize;
        private int _zoomSpeedMultiplier = 10;
        private float _diff;

        public TFivePictureBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(100, 100);
            UpdateGraphicsBuffer();
        }

        private void UpdateGraphicsBuffer()
        {
            if (Width > 0 && Height > 0)
            {
                _bufContext.MaximumBuffer = new Size(Width + 1, Height + 1);
                _bufGraphics = _bufContext.Allocate(CreateGraphics(), ClientRectangle);
                _bufGraphics.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_imageRect.Width > _imageRect.Height)
            {
                if (_lastSize.Width < ClientSize.Width &&
                    _mode == DisplayMode.Zoomable && _imageRect.Width < Width)
                {
                    SetImageWidth(Width);
                }
            }
            else
            {
                if (_lastSize.Height < ClientSize.Height &&
                    _mode == DisplayMode.Zoomable && _imageRect.Height < Height)
                {
                    SetImageHeight(Height);
                }
            }

            UpdateGraphicsBuffer();
            _lastSize = Size;
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _bufGraphics.Graphics.Clear(BackColor);

            if (Image != null)
            {
                switch (_mode)
                {
                    case DisplayMode.Normal: DrawImageNormal(); break;
                    case DisplayMode.Center: DrawImageCentered(); break;
                    case DisplayMode.Fill: DrawImageFilled(); break;
                    case DisplayMode.Stretch: DrawImageStretched(); break;
                    case DisplayMode.Zoomable: DrawImageWithRect(); break;
                }
            }

            _bufGraphics.Render(e.Graphics);
        }

        private void DrawImageWithRect()
        {
            if (_imageRect.Width <= 0) _imageRect.Width = _image.Width;
            if (_imageRect.Height <= 0) _imageRect.Height = _image.Height;
            _bufGraphics.Graphics.DrawImage(_image, _imageRect);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RightClickCMS.Show(PointToScreen(e.Location));
            }

            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button.Equals(MouseButtons.Left))
            {
                if (Image != null && _mode == DisplayMode.Zoomable && Cursor == Cursors.Default)
                    Cursor = Cursors.Hand;

                float x = _imageRect.Left + e.X - _lastPos.X;
                float y = _imageRect.Top + e.Y - _lastPos.Y;
                _imageRect.Location = new PointF(x, y);
                _lastPos = e.Location;
                Invalidate();
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
                _diff = (e.Y - _lastPos.Y) * _zoomSpeedMultiplier;

                float height = _imageRect.Height + _diff;
                float ratio = height / _imageRect.Height;
                // We need to alter the width according to the change in height
                float width = _imageRect.Width * ratio;
                // Set x and y so the image sizes around its center
                float x = _imageRect.X + (_imageRect.Width - width) / 2f;
                float y = _imageRect.Y + (_imageRect.Height - height) / 2f;

                // makes for cleaner zooming (anchor top or left under certain circumstances)
                if (x > 0 || _imageRect.Width < Width) x = 0;
                if (y > 0 || _imageRect.Height < Height) y = 0;

                // If not shrinking and image is above 3x3 pixels
                if (!(_diff < 0 && (width < 3 || height < 3)))
                {
                    _imageRect = new RectangleF(x, y, width, height);
                }

                _lastPos = e.Location;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _lastPos = e.Location;

            // If there is an image and in zoom mode and button is left
            if (Image != null && _mode == DisplayMode.Zoomable)
            {
                if (e.Button == MouseButtons.Left)
                    Cursor = Cursors.Hand;
                else if (e.Button == MouseButtons.Right)
                    Cursor = Cursors.NoMoveVert;
            }
        }

        private void SetImageWidth(int width)
        {
            double ratio = (double)width / _imageRect.Width;
            _imageRect.Width = width;
            _imageRect.Height = (float)(_imageRect.Height * ratio);
        }

        private void SetImageHeight(int height)
        {
            double ratio = (double)height / _imageRect.Height;
            _imageRect.Height = height;
            _imageRect.Width = (float)(_imageRect.Width * ratio);
        }

        private void AlignImageRectangle()
        {
            bool smallWidth = false;
            bool smallHeight = false;

            // Test to see if the image is smaller than the control and the width is the biggest dimension
            if (_imageRect.Width > _imageRect.Height && _imageRect.Width < ClientSize.Width)
            {
                smallWidth = true;
                _imageRect.Location = new PointF(0, _imageRect.Y);
                SetImageWidth(ClientSize.Width);
            }
            else if (_imageRect.X > 0) // We do not want to drag to far right
            {
                _imageRect.Location = new PointF(0, _imageRect.Location.Y);
            }
            else if (_imageRect.X + _imageRect.Width < ClientSize.Width) // We do not want to drag to far left
            {
                if (_imageRect.Width >= ClientSize.Width)
                    _imageRect.Location = new PointF(ClientSize.Width - _imageRect.Width, _imageRect.Location.Y);
                else
                    _imageRect.Location = new PointF(0, _imageRect.Location.Y);
            }

            // Test to see if the image is smaller than the control and the height is the biggest dimension
            if (_imageRect.Width < _imageRect.Height && _imageRect.Height < ClientSize.Height)
            {
                smallHeight = true;
                _imageRect.Location = new PointF(_imageRect.X, 0);
                SetImageHeight(ClientSize.Height);
            }
            else if (_imageRect.Y > 0) // We do not want to drag to far down
            {
                _imageRect.Location = new PointF(_imageRect.Location.X, 0);
            }
            else if (_imageRect.Y + _imageRect.Height < ClientSize.Height) // We do not want to drag to far up
            {
                _imageRect.Location = new PointF(_imageRect.X, ClientSize.Height - _imageRect.Height);
            }

            if (smallHeight && smallWidth)
            {
                DrawImageCentered();
                Invalidate();
                return;
            }

            // Keep us from dragging the image to far up when the image is smaller than the control
            if (_imageRect.Height < ClientSize.Height)
            {
                _imageRect.Location = new PointF(_imageRect.X, 0);
            }

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor = Cursors.Default;
            AlignImageRectangle();
        }

        private void DrawImageFilled()
        {
            float width = Width; // The new image width (for drawing only)
            float height = Height; // The new image height
            float x = 0;
            float y = 0;
            // Get image to control dimension ratio
            float ratio1 = Image.Width / width;
            float ratio2 = Image.Height / height;

            // Whatever ratio is greatest is the ratio to be applied
            if (ratio1 < ratio2)
            {
                // Apply ratio to the height of the image (we dont need to touch the width)
                height = Image.Height / ratio1;
                // Center the image on the y, it will be left 0 on the x
                y = Height / 2f - height / 2f;
            }
            else if (ratio2 < ratio1) // do the exact same thing, just for the other dimension
            {
                width = Image.Width / ratio2;
                x = Width / 2f - width / 2f;
            }

            _bufGraphics.Graphics.DrawImage(Image, x, y, width, height);
        }

        private void DrawImageCentered()
        {
            float width = ClientSize.Width; // The new image width (for drawing only)
            float height = ClientSize.Height; // The new image height
            float x = 0;
            float y = 0;
            // Get image to control dimension ratio
            float ratio1 = Image.Width / (float)ClientSize.Width;
            float ratio2 = Image.Height / (float)ClientSize.Height;

            // Whatever ratio is greatest is the ratio to be applied
            if (ratio1 > ratio2)
            {
                // Apply ratio to the height of the image (we dont need to touch the width)
                height = Image.Height / ratio1;
                // Center the image on the y, it will be left 0 on the x
                y = ClientSize.Height / 2f - height / 2f;
            }
            else if (ratio2 > ratio1) // do the exact same thing, just for the other dimension
            {
                width = Image.Width / ratio2;
                x = ClientSize.Width / 2f - width / 2f;
            }

            _bufGraphics.Graphics.DrawImage(Image, x, y, width, height);
        }

        /// <summary>
        /// Same as draw image normal except the image is resized to be completely visible
        /// </summary>
        private void DrawImageTopLeft()
        {
            float width = Width; // The new image width (for drawing only)
            float height = Height; // The new image height
            // Get image to control dimension ratio
            float ratio1 = Image.Width / width;
            float ratio2 = Image.Height / height;

            // Whatever ratio is greatest is the ratio to be applied
            if (ratio1 > ratio2)
            {
                // Apply ratio to the height of the image (we dont need to touch the width)
                height = Image.Height / ratio1;
                // Center the image on the y, it will be left 0 on the x
            }
            else if (ratio2 > ratio1) // do the exact same thing, just for the other dimension
            {
                width = Image.Width / ratio2;
            }

            _imageRect = new RectangleF(0, 0, width, height);
        }

        private void DrawImageNormal()
        {
            _bufGraphics.Graphics.DrawImage(_image, _imageRect);
        }

        private void DrawImageStretched()
        {
            _bufGraphics.Graphics.DrawImage(Image, ClientRectangle);
        }

        [Category("Appearance")]
        [DefaultValue(null)]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                _imageRect = new RectangleF(Point.Empty, _image.Size);

                if (Image != null && _mode == DisplayMode.Zoomable)
                {
                    DrawImageTopLeft();
                }

                Invalidate();
            }
        }

        [Category("Layout")]
        [DefaultValue(DisplayMode.Center)]
        [Description("Determines how the image will be displayed")]
        public DisplayMode SizeMode
        {
            get { return _mode; }
            set
            {
                // if changing from zoomable then set cursor to default
                if (_mode == DisplayMode.Zoomable && value != DisplayMode.Zoomable)
                {
                    Cursor = Cursors.Default;

                    if (Image != null)
                        DrawImageTopLeft();
                }

                _mode = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(10)]
        [Description("Determines how fast to zoom in zoom mode. Its recommended to keep this value between 0 and 15")]
        public int ZoomSpeedMultiplier
        {
            get { return _zoomSpeedMultiplier; }
            set { _zoomSpeedMultiplier = value; }
        }

        [Category("Behavior")]
        [DefaultValue(null)]
        [Description("The context to show when you right-click the control (or double right-click in zoom mode)")]
        public ContextMenuStrip RightClickCMS { get; set; }
    }
}
