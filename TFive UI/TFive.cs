using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TFive_Theme;

namespace TFive
{
    internal sealed class TFive
    {
        static TFive()
        {
        }
        internal static Graphics G;
        internal static Bitmap B;

        internal static StringFormat nearSf = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };

        public enum MouseState : byte
        {
            None,
            Over,
            Down
        }
    }

    [DebuggerStepThrough]
    [ProvideProperty("TFiveFramework", typeof(Control))]
    public class TFiveElipse : Component
    {
        public TFiveElipse()
        {
            InitializeComponent();
            if (TargetControl == null)
            {
                TargetControl = ContainerControl;
            }
        }

        private ContainerControl ContainerControl
        {
            get => _containerControl;
            set
            {
                _containerControl = value;
                ApplyElipse();
            }
        }

        public override ISite Site
        {
            get => base.Site;
            set
            {
                base.Site = value;
                var designerHost = value?.GetService(typeof(IDesignerHost)) as IDesignerHost;
                var rootComponent = designerHost?.RootComponent;
                if (rootComponent is ContainerControl)
                {
                    ContainerControl = (rootComponent as ContainerControl);
                }
            }
        }



        private void _control_Resize(object sender, EventArgs e)
        {
            Elipse.Apply(_control, _radius);
        }

        public TFiveElipse(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public Control TargetControl
        {
            get => _control;
            set => _control = value;
        }

        public int ElipseRadius
        {
            get => _radius;
            set
            {
                _radius = value;
                ApplyElipse();
            }
        }

        public void ApplyElipse(int Radius)
        {
            if (_control != null)
            {
                Elipse.Apply(_control, Radius);
            }
        }

        public void ApplyElipse()
        {
            if (_control != null)
            {
                Elipse.Apply(_control, _radius);
            }
        }

        public void ApplyElipse(Control control, int Radius)
        {
            if (control != null)
            {
                Elipse.Apply(control, Radius);
            }
        }

        public void ApplyElipse(Control control)
        {
            if (control != null)
            {
                Elipse.Apply(control, _radius);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (_control != null)
            {
                _control.Resize += _control_Resize;
            }
            else
            {
                _control = ContainerControl;
                _control.Resize += _control_Resize;
            }
            if (_control.GetType() == typeof(Form))
            {
                ((Form)_control).FormBorderStyle = FormBorderStyle.None;
            }
            ApplyElipse();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            timer1 = new Timer(components);
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
        }

        private ContainerControl _containerControl;

        private Control _control;

        private int _radius = 5;

        private IContainer components;

        private Timer timer1;
    }

    [DebuggerStepThrough]
    [ProvideProperty("TFiveFramework", typeof(Control))]
    public class TFiveDragControl : Component
    {
        public TFiveDragControl()
        {
            InitializeComponent();
        }

        public TFiveDragControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void Grab(Control _control)
        {
            d.Grab(_control);
        }

        public void Grab()
        {
            Control containerControl = _containerControl;
            d.Grab(containerControl);
        }

        public void Release()
        {
            d.Release();
        }

        public void Drag(bool horixontal = true, bool Vertical = true)
        {
            d.MoveObject(Vertical, horixontal);
        }

        public Control TargetControl
        {
            get => target;
            set => target = value;
        }

        private ContainerControl containerControl
        {
            get => _containerControl;
            set => _containerControl = value;
        }

        public override ISite Site
        {
            get => base.Site;
            set
            {
                base.Site = value;
                if (value == null)
                {
                    return;
                }
                var designerHost = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                {
                    var rootComponent = designerHost.RootComponent;
                    if (rootComponent is ContainerControl)
                    {
                        containerControl = (rootComponent as ContainerControl);
                    }
                }
            }
        }

        public bool Fixed
        {
            get => _fixed;
            set => _fixed = value;
        }

        public bool Vertical
        {
            get => _vertical;
            set => _vertical = value;
        }

        public bool Horizontal
        {
            get => _Horizontal;
            set => _Horizontal = value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Control containerControl = this.containerControl;
            if (target != null)
            {
                containerControl = target;
            }
            containerControl.MouseDown += _c_MouseDown;
            containerControl.MouseMove += _c_MouseMove;
            containerControl.MouseUp += _c_MouseUp;
        }

        private void _c_MouseMove(object sender, MouseEventArgs e)
        {
            Drag(Vertical, Horizontal);
        }

        private void _c_MouseUp(object sender, MouseEventArgs e)
        {
            Release();
        }

        private void _c_MouseDown(object sender, MouseEventArgs e)
        {
            if (_fixed)
            {
                var control = (Control)sender;
                while (control.Parent != null)
                {
                    control = control.Parent;
                }
                Grab(control);
                return;
            }
            Grab((Control)sender);
        }

        private void InitializeComponent()
        {
            components = new Container();
            timer1 = new Timer(components) {Enabled = true, Interval = 1};
            timer1.Tick += timer1_Tick;
        }

        private Drag d = new Drag();

        public Control target;

        public ContainerControl _containerControl;

        public bool _fixed = true;

        public bool _vertical = true;

        public bool _Horizontal = true;

        private IContainer components;

        private Timer timer1;
    }

    [DebuggerStepThrough]
    [ProvideProperty("TFiveFramework", typeof(Control))]
    internal class Drag : Form
    {
        public void Grab(Control a)
        {
            try
            {
                that = a;
                leftClick = true;
                intX = MousePosition.X - that.Left;
                intY = MousePosition.Y - that.Top;
            }
            catch (Exception)
            {
                //
            }
        }

        public void Release()
        {
            leftClick = false;
        }

        public void MoveObject(bool Horizontal = true, bool Vertical = true)
        {
            try
            {
                if (leftClick)
                {
                    var x = MousePosition.X;
                    var y = MousePosition.Y;
                    if (Vertical)
                    {
                        that.Top = y - intY;
                    }
                    if (Horizontal)
                    {
                        that.Left = x - intX;
                    }
                }
            }
            catch 
            {
                //
            }
        }

        private bool leftClick;

        private int intX;

        private int intY;

        private Control that;
    }





}
