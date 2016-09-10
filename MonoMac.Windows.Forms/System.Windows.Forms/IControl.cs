using MonoMac.AppKit;
using System;
using System.Drawing;

namespace System.Windows.Forms
{
    public interface IControl
    {
        Color BackColor { get; set; }
    }

    public interface INSControlCell : IControl
    {
        NSColor BackgroundColor { get; set; }
    }
}

