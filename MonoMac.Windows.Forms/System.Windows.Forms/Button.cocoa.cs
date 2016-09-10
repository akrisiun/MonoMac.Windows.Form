using System;
using MonoMac.AppKit; // using AppKit;
// using ObjCRuntime;
using MonoMac.Foundation; // using Foundation;
using Foundation = MonoMac.Foundation;

using System.Drawing;
using System.Collections.Generic;

namespace System.Windows.Forms
{

    internal class ButtonHelper : NSView, IControl // UserControl
    {
        public Control Host { get; internal set; }
        // public RectangleF Frame { get; internal set; }

        public INSControlCell Cell { get; internal set; }

        // BackgroundColor

        public NSBezelStyle BezelStyle;
        public bool AllowsMixedState;
        public bool Enabled;
        public NSCellStateValue State;

        // public abstract bool IsFlipped { get; }

        public event EventHandler Activated;

        public virtual void ScaleUnitSquareToSize(object scale) { } // Util.ScaleSize);
        public virtual void SetButtonType(NSButtonType type) { } // .Switch);
        public virtual void SizeToFit() { }

        // TODO too
        public virtual Color BackColor { get; set; }
        public virtual Color BackgroundColor { get; set; }
        public Font Font { get; set; }
        public virtual string Title { get; set; }
    }

    public partial class Button
    {
        #region Public Constructors

        public Button()
            : base()
        {
            SetStyle(ControlStyles.StandardDoubleClick, false);
        }

        protected override void CreateHandle()
        {
            ButtonHelper helper = new ButtonHelper();
            m_view = helper;
            helper.Font = Font; //.ToNsFont();
            helper.Host = this;
            helper.BezelStyle = NSBezelStyle.Rounded;

            helper.Activated += delegate(object sender, EventArgs e)
            {
                OnClick(e);
            };
            helper.Frame = new System.Drawing.RectangleF(0, 0, 100, 25);
            helper.ScaleUnitSquareToSize(Util.ScaleSize);
        }
        #endregion	// Public Constructors

        //[Obsolete("Not Implemented.", false)]
        //public bool UseVisualStyleBackColor { get; set; }

        public new Color BackColor
        {
            get
            {
                ButtonHelper bh = m_view as ButtonHelper;
                if (bh != null)
                    return bh.Cell.BackgroundColor.ToColor();
                return background_color;
            }
            set
            {
                ButtonHelper bh = m_view as ButtonHelper;
                if (bh != null)
                    bh.Cell.BackgroundColor = value.ToNSColor();
                background_color = value;
            }
        }

        /*
        public override void MouseUp (NSEvent theEvent)
        {
			
            PointF point = theEvent.LocationInWindow;
			

            if(MouseUp != null)
                MouseUp(this, new MouseEventArgs (MouseButtons.Left, theEvent.ClickCount, (int)point.X, (int)point.Y, 0));
            base.MouseUp (theEvent);
        }
        */

        private bool autoSize;

        public new bool AutoSize { get { return autoSize; } set { autoSize = value; resize(); } }

        internal override bool enabled
        {
            get
            {
                ButtonHelper bh = m_view as ButtonHelper;
                if (bh != null)
                    enabled = bh.Enabled;
                return enabled;
            }
            set
            {
                enabled = value;
                ButtonHelper bh = m_view as ButtonHelper;
                if (bh != null)
                    bh.Enabled = value;
            }
        }
    }
}

