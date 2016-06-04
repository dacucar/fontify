using Xwt;

namespace Fontify
{
    public class ConcealableCheckPanel : Widget
    {
        private VBox vbox;

        public CheckBox TitleCheckBox { get; }

        private Widget concelableContent;

        public Widget ConcealableContent
        { 
            get
            {
                return concelableContent;
            }

            set
            {
                if ( concelableContent != null )
                {
                    vbox.Remove ( concelableContent );
                }

                concelableContent = value;
                updateConcelableContentVisibility ();

                vbox.PackStart ( concelableContent, true );
            }
        }

        public string Text
        {
            get
            {
                return TitleCheckBox.Label;
            }
            set
            {
                TitleCheckBox.Label = value;
            }
        }

        public bool Concealed
        { 
            get
            {
                return ( ConcealableContent == null
                || !ConcealableContent.Visible );
            }
            set
            { 
                if ( ConcealableContent != null )
                {
                    ConcealableContent.Visible = !value;
                }
            }
        }


        public ConcealableCheckPanel ()
        {
            vbox = new VBox ();
            TitleCheckBox = new CheckBox ();

            TitleCheckBox.Toggled += (sender, e ) =>
            {
                updateConcelableContentVisibility ();
            };

            vbox.PackStart ( TitleCheckBox );

            Content = vbox;
        }

        private void updateConcelableContentVisibility ()
        {
            Concealed = ( TitleCheckBox.State == CheckBoxState.Off );
        }
    }
}

