using Xwt;
using System.Diagnostics;
using System.Linq;

namespace Fontify.GlyphDesigner
{
    public class GlyphDesignerWindow : Window
    {
        public Stack stack;
        public StackSideBar sideBar;
        public PreviewPanel previewPanel;

        public GlyphDesignerWindow ()
        {
            Title = "Glyph Designer";
            Width = 640;
            Height = 360;

            BuildUI ();
        }

        protected override bool OnCloseRequested ()
        {
            var allow_close = MessageDialog.Confirm ( "Fontify will be closed", Command.Ok );

            if ( allow_close )
            {
                Application.Exit ();
            }
            
            return allow_close;
        }

        private void BuildUI ()
        {
            HBox container = new HBox ();

            stack = new Stack ();
            stack.AddTitled ( new FontPanel (), "font", "Font" );
            stack.AddTitled ( new OutlinePanel (), "outline", "Outline" );
            stack.AddTitled ( new FillPanel (), "fill", "Fill" );
            stack.AddTitled ( new ShadowPanel (), "shadow", "Shadow" );
            stack.HorizontalPlacement = WidgetPlacement.Start;

            sideBar = new StackSideBar ();
            sideBar.Stack = stack;
            sideBar.HorizontalPlacement = WidgetPlacement.Start;
            sideBar.MinWidth = 200; // TODO: Should be automatic

            previewPanel = new PreviewPanel ();

            container.PackStart ( sideBar );
            container.PackStart ( stack, true );
            container.PackStart ( previewPanel );

            Content = container;
        }

    }
}


