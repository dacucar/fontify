using Xwt;

namespace Fontify
{
    public class StackSideBar : VBox
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
                stack.PageAdded += OnStackContentsChanged;
                stack.PageRemoved += OnStackContentsChanged;
                UpdateListContents ();
            } 
        }

        public StackSideBar ()
        {
            listBox = new ListBox ();
            listBox.SelectionChanged += OnSelectionChanged;
			PackStart(listBox, true);
        }

        public void OnSelectionChanged ( object sender, System.EventArgs e )
        {
            stack.SetVisiblePage ( listBox.SelectedRow );
        }

        private void OnStackContentsChanged ( object sender, System.EventArgs e )
        {
            UpdateListContents ();
        }

		/*protected override Size OnGetPreferredSize(SizeConstraint widthConstraint, SizeConstraint heightConstraint)
		{
			if (stack == null)
			{
				return new Size(-1, -1);
			}

			return listBox.Surface.GetPreferredSize(widthConstraint, heightConstraint);
		}*/

        private void UpdateListContents ()
        {
			listBox.Items.Clear();
			foreach (var s in stack.PageTitles)
			{
				listBox.Items.Add(s);
			}
        }
    }
}

