using Xwt;

namespace Fontify
{
	public class PreviewPanel : VBox
	{
		public Slider SizeSlider;
		public CheckBox AutoscaleCheckBox;
		public ImageView PreviewImage;
		public Button ConfigButton;
		public Label PreviewLabel;

		public PreviewPanel()
		{
			PreviewLabel = new Label("Preview");
			ConfigButton = new Button("C");

			PreviewImage = new ImageView();

			AutoscaleCheckBox = new CheckBox("Auto-scale");
			SizeSlider = new HSlider();

			var hbox1 = new HBox();
			hbox1.PackStart(PreviewLabel, true);
			hbox1.PackStart(ConfigButton);

			PackStart(hbox1);
			PackStart(PreviewImage, true);
			PackStart(AutoscaleCheckBox);
			PackStart(SizeSlider);
		}
	}
}

