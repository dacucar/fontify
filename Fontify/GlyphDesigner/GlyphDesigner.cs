using System;
using Xwt;
using Xwt.Drawing;

namespace Fontify.GlyphDesigner
{
    public class GlyphDesigner
    {
        public GlyphDesigner ()
        {
            Font = Xwt.Drawing.Font.SystemFont;
        }

        public char Character { get; set; }

        public Font Font { get; }

        public void Render ( Context ctx )
        {
            ctx.SetColor ( new Color ( 1.0, 0.0, 0.0 ) );
            ctx.SetLineWidth ( 1.0 );
            
            var textLayout = new TextLayout ();
            textLayout.Font = this.Font.WithSize ( 60 );
            textLayout.Text = Character.ToString ();

            ctx.NewPath ();
            ctx.TextLayoutPath ( textLayout, 0, 0 );
            ctx.StrokePreserve ();
            
        }
    }
}

