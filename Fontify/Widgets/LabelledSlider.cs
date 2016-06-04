using Xwt;

namespace Fontify
{
    public class LabelledSlider : Widget
    {
        public Slider Slider { get; }

        public Label Label { get; }

        public double MinimumValue
        {
            get
            {
                return Slider.MinimumValue;
            }
            set
            {
                Slider.MinimumValue = value;
            }
        }

        public double MaximumValue
        {
            get
            {
                return Slider.MaximumValue;
            }
            set
            {
                Slider.MaximumValue = value;
            }
        }

        public double StepIncrement
        {
            get
            {
                return Slider.StepIncrement;
            }
            set
            {
                Slider.StepIncrement = value;
            }
        }

        public double Value
        {
            get
            {
                return Slider.Value;
            }
            set
            {
                Slider.Value = value;
            }
        }

        public string Format { get; set; }

        public LabelledSlider ()
        {
            Label = new Label ();
            Label.TextAlignment = Alignment.Center;
            Format = "F0";

            Slider = new HSlider ();
            Slider.ValueChanged += (sender, e ) =>
            {
                Label.Text = ( Slider.Value ).ToString ( Format );
            };

            Slider.Value = 1;

            var container = new HBox ();
            container.PackStart ( Slider, true, true );
            container.PackStart ( Label );

            Content = container;
        }
    }
}

