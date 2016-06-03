using Xwt;

namespace Fontify.GlyphDesigner
{
	public class FontPanel : VBox
	{
		private Slider slider;
		private ComboBox fontType;
		private ListBox fontList;

		internal void UpdateFonts(string[] fonts)
		{
			fontList.DataSource = new SimpleListDataSource(fonts);
		}

		public FontPanel()
		{
			fontList = new ListBox();
			fontList.ExpandHorizontal = true;
			fontList.ExpandVertical = true;

			fontType = new ComboBox();
			fontType.ItemsSource = new SimpleListDataSource(new string[] { "Regular", "Italic", "Bold" });


			var sliderText = new Label();
			sliderText.TextAlignment = Alignment.Center;

			slider = new HSlider()
			{
				MinimumValue = 4,
				MaximumValue = 200,
				StepIncrement = 1
			};

			slider.ValueChanged += (sender, e) =>
			{
				sliderText.Text = (slider.Value).ToString("F0");
			};

			slider.Value = 12;

			var sliderContainer = new HBox();
			sliderContainer.PackStart(slider, true, true);
			sliderContainer.PackEnd(sliderText);

			PackStart(fontList, true, true);
			PackStart(fontType);
			PackStart(sliderContainer);
		}

		public string FontName
		{
			get
			{
				return fontList.SelectedItem.ToString();
			}
		}

		public int FontSize
		{
			get
			{
				return (int) slider.Value;
			}
		}

		public string FontType
		{
			get
			{
				return fontType.SelectedText;
			}
		}
	}
}

