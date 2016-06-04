using System;
using Xwt;
using Fontify.GlyphDesigner;

namespace Fontify.Gtk2
{
    public class Program
    {
        [STAThread]
        public static void Main ( string [] args )
        {
            Application.Initialize ( ToolkitType.Gtk );

            var w = new GlyphDesignerWindow ();
            w.Show ();

            Application.Run ();

            w.Dispose ();
            Application.Dispose ();
        }
    }
}

