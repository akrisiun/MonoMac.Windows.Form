using System;
using MonoMac.AppKit; // using AppKit;
using System.Drawing;
using MonoMac.Foundation; // using Foundation;

namespace System.Windows.Forms
{
    // ankr TODO
    internal partial class PanelMouseView : UserControl
    {
        public ScrollableControl Host { get; internal set; }

        public RectangleF Frame;
        public virtual void AddTrackingArea(object trackingArea) { }
    }

    public partial class Panel : ScrollableControl // : PanelMouseView
    //NSView
    {
        internal PanelMouseView m_helper;

        internal NSTrackingArea trackingArea;
        protected override void CreateHandle()
        {
            m_helper = new PanelMouseView();
            m_view = m_helper;
            m_helper.Host = this;
            trackingArea = new NSTrackingArea(m_helper.Frame, (NSTrackingAreaOptions.MouseEnteredAndExited |
                                                                         NSTrackingAreaOptions.MouseMoved |
                                                                         NSTrackingAreaOptions.ActiveInKeyWindow), m_helper, new NSDictionary());
            m_helper.AddTrackingArea(trackingArea);
        }
        #region Setup
        #endregion

        #region Simple Public Properties

        #endregion
    }
}

