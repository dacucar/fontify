using Xwt;

namespace Fontify
{
    public class StackSideBar : Widget
    {
        private ListBox listBox;

        private Stack stack;

        public Stack Stack
        { 
            get
            {
                return stack;
            }

            set
            {
                stack = value;
                stack.ChildAdded += OnStackContentsChanged;
                stack.ChildRemoved += OnStackContentsChanged;
                UpdateListContents ();
            } 
        }

        public StackSideBar ()
        {
            listBox = new ListBox ();
            listBox.ExpandHorizontal = true;
            listBox.SelectionChanged += OnSelectionChanged;
            Content = listBox;
        }

        public void OnSelectionChanged ( object sender, System.EventArgs e )
        {
            stack.SetVisibleChild ( stack.Names[listBox.SelectedRow] );
        }

        private void OnStackContentsChanged ( object sender, System.EventArgs e )
        {
            UpdateListContents ();
        }

        private void UpdateListContents ()
        {
            listBox.DataSource = new SimpleListDataSource ( stack.Titles );
        }
    }
}

