using Xwt;

namespace Fontify
{
    public class MainWindow : Window
    {
        public MainWindow ()
        {
            Title = "Fontify";
            Width = 400;
            Height = 400;

            var mainContainer = new VBox ();
            HBox container = new HBox ();
            Stack stack = new Stack ();
            stack.AddTitled ( new Label ( "Hola Caracola" ), "label1", "Title 0" );
            stack.AddTitled ( new Button ( "Hola2" ), "label2", "Title 1" );

            StackSideBar sideBar = new StackSideBar ();
            sideBar.Stack = stack;
            sideBar.ExpandHorizontal = true;
            container.ExpandHorizontal = true;

            sideBar.MinWidth = sideBar.Surface.GetPreferredSize ().Width;
            container.PackStart ( sideBar );
            container.PackStart ( stack );

            mainContainer.PackStart ( container );
            Content = mainContainer;
            mainContainer.ExpandVertical = true;

            Menu menu = new Menu ();

            var file = new MenuItem ( "_File" );
            file.SubMenu = new Menu ();
            file.SubMenu.Items.Add ( new MenuItem ( "_Open" ) );
            file.SubMenu.Items.Add ( new MenuItem ( "_New" ) );
            MenuItem mi = new MenuItem ( "_Close" );
            mi.Clicked += (sender, e ) => Close ();
            file.SubMenu.Items.Add ( mi );
            menu.Items.Add ( file );
            MainMenu = menu;

        
        }

        protected override bool OnCloseRequested ()
        {
            var allow_close = MessageDialog.Confirm ( "Fontify will be closed", Command.Ok );
            if ( allow_close )
                Application.Exit ();
            return allow_close;
        }
    }
}


