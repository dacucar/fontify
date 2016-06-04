using Xwt;
using Xwt.Drawing;

namespace Fontify.GlyphDesigner
{
    public class FillPanel : ConcealableCheckPanel
    {
        public FillPanel ()
            : base ()
        {
            Text = "Use fill";

            var fillOptions = new Notebook ();
            fillOptions.Add ( new Label (), "Solid" );
            fillOptions.Add ( new Label (), "Gradient" );
            fillOptions.Add ( new Label (), "Image" );

            ConcealableContent = fillOptions;
        }
    }
}

