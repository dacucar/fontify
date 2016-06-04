using Xwt;

namespace Fontify.GlyphDesigner
{
    public class OutlinePanel : ConcealableCheckPanel
    {
        LabelledSlider widthSlider;
        Label widthLabel;

        public OutlinePanel ()
            : base ()
        {
            Text = "Outline Text";

            widthSlider = new LabelledSlider ()
            {
                MinimumValue = 1,
                MaximumValue = 32,
                StepIncrement = 1,
                Value = 1
            };

            widthLabel = new Label ( "Width" );

            var vbox = new VBox ();
            vbox.PackStart ( widthLabel );
            vbox.PackStart ( widthSlider );

            ConcealableContent = vbox;
        }

    }
}

