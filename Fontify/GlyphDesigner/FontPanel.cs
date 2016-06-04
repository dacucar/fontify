using Xwt;

namespace Fontify.GlyphDesigner
{
    public class FontPanel : VBox
    {
        private LabelledSlider slider;
        private ComboBox fontType;
        private ListBox fontList;

        public FontPanel ()
        {
            fontList = new ListBox ();
            fontList.ExpandHorizontal = true;
            fontList.ExpandVertical = true;
            loadFonts ();

            fontType = new ComboBox ();
            fontType.ItemsSource = new SimpleListDataSource ( 
                new string[] { "Regular", "Italic", "Bold" } );

            slider = new LabelledSlider ()
            {
                MinimumValue = 4,
                MaximumValue = 200,
                StepIncrement = 1
            };

            slider.Value = 12;

            PackStart ( fontList, true, true );
            PackStart ( fontType );
            PackStart ( slider );
        }

        public string FontName
        {
            get
            {
                return fontList.SelectedItem.ToString ();
            }
        }

        public int FontSize
        {
            get
            {
                return ( int ) slider.Value;
            }
        }

        public string FontType
        {
            get
            {
                return fontType.SelectedText;
            }
        }

        private void loadFonts ()
        {
            fontList.DataSource = new SimpleListDataSource (
                Xwt.Drawing.Font.AvailableFontFamilies );
        }

    }
}

