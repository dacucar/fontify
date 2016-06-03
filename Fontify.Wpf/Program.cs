using System;
using Xwt;
using Fontify.GlyphDesigner;

namespace Fontify.Wpf
{
    public class Program
    {
        [STAThread]
        public static void Main ( string [] args )
        {
            Application.Initialize ( ToolkitType.Wpf );

            GlyphDesigner.GlyphDesignerWindow w = new GlyphDesigner.GlyphDesignerWindow ();
            w.Show ();

            Application.Run ();

            w.Dispose ();
            Application.Dispose ();
        }
    }
}

