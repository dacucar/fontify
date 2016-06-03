using System;
using Xwt;
using Fontify.GlyphDesigner;
using Fontify.Pango;
using Gtksharp = Gtk;

namespace Fontify.Gtk2
{
    public class Program
    {
        [STAThread]
        public static void Main ( string [] args )
        {
            Application.Initialize ( ToolkitType.Gtk );

            GlyphDesigner.GlyphDesignerWindow w = new GlyphDesigner.GlyphDesignerWindow ();
            w.Show ();
			//var windowBackEnd = (Xwt.GtkBackend.WindowBackend);
			//w.FontFamiliesSource = new PangoFontFamiliesSource();
			

            Application.Run ();

            w.Dispose ();
            Application.Dispose ();
        }
    }
}

