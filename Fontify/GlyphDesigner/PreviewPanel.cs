using Xwt;

namespace Fontify.GlyphDesigner
{
    public class PreviewGlyphCanvas : Canvas
    {
        protected override void OnDraw ( Xwt.Drawing.Context ctx, Rectangle dirtyRect )
        {
            //base.OnDraw (ctx, dirtyRect);
            var designer = new GlyphDesigner ();
            designer.Character = 'A';
            designer.Font.WithSize ( 50 ).WithFamily ( "San Serif" );
            designer.Render ( ctx );
        }
    }

    public class PreviewPanel : VBox
    {
        public Slider SizeSlider;
        public CheckBox AutoscaleCheckBox;
        public Canvas PreviewImage;
        public Button ConfigButton;
        public Label PreviewLabel;

        public PreviewPanel ()
        {
            PreviewImage = new PreviewGlyphCanvas ();
            PreviewLabel = new Label ( "Preview" );
            ConfigButton = new Button ( "C" );
            /*ConfigButton.ButtonPressed += (sender, e ) =>
            {

            };*/

            AutoscaleCheckBox = new CheckBox ( "Auto-scale" );
            SizeSlider = new HSlider ();

            var hbox1 = new HBox ();
            hbox1.PackStart ( PreviewLabel, true );
            hbox1.PackStart ( ConfigButton );

            PackStart ( hbox1 );
            PackStart ( PreviewImage, true );
            PackStart ( AutoscaleCheckBox );
            PackStart ( SizeSlider );
        }
    }
}

