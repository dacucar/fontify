using System;
using Xwt;
using Fontify.Pango;
using Fontify.GlyphDesigner;

namespace Fontify.Gtk3
{
    public class Program
    {
        [STAThread]
        public static void Main ( string [] args )
        {
            Application.Initialize ( ToolkitType.Gtk3 );

            GlyphDesigner.GlyphDesignerWindow w = new GlyphDesigner.GlyphDesignerWindow ();
            w.Show ();

            Application.Run ();

            w.Dispose ();
            Application.Dispose ();
        }
    }
}

