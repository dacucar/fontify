using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xwt;

namespace Fontify
{
    public class Stack : Widget
    {
        private ICollection<StackPage> pages;
		private string visiblePageName;

        public event EventHandler PageAdded;
        public event EventHandler PageRemoved;

        public Stack ()
        {
        }

		public Widget this[string name]
		{
			get
			{
				return pages.First(_ => _.Name == name).Widget;
			}
		}

		public Widget VisiblePage
        {
            get
            { 
				return pages.First(_ => _.Name == visiblePageName).Widget;
            }
        }

		public void SetVisiblePage ( int index )
		{
			if ( pages == null || index < 0 || index >= pages.Count() )
			{
				throw new ArgumentOutOfRangeException();
			}

			setVisiblePage(pages.ElementAt(index));
		}

        public void SetVisiblePage ( string name )
        {
			if ( !pages.Select(_ => _.Name).Contains ( name ) )
            {
                throw new ArgumentException ();
            }

			var page = pages.First(_ => _.Name == name);

			setVisiblePage(page);
        }

		public string GetVisiblePageName ()
        {
			return visiblePageName;
        }

        public string[] PageNames
        {
            get
            {
                return pages.Select ( _ => _.Name ).ToArray ();
            }
        }


        public string[] PageTitles
        {
            get
            {
                return pages.Select ( _ => _.Title ).ToArray ();
            }
        }

        public void AddNamed ( Widget widget, string name )
        {
            addChild ( widget, name );
        }

        public void AddTitled ( Widget widget, string name, string title )
        {
            addChild ( widget, name, title );
        }

        public void Remove ( string name )
        {
            if ( pages.Remove(pages.First(_ => _.Name == name)) 
			    && PageRemoved != null )
            {
                PageRemoved.Invoke ( this, EventArgs.Empty );
            }
        }

		private void setVisiblePage(StackPage page)
		{
			visiblePageName = page.Name;
			Content = page.Widget;
		}

        private void addChild ( Widget widget, string name, string title = "" )
        {

            if ( pages == null )
            {
				pages = new List<StackPage>();
            }

			if (pages.Select(_ => _.Name).Contains(name))
			{
				throw new ArgumentException();
			}

            var child = new StackPage (){ Name = name, Title = title, Widget = widget };

            pages.Add ( child );

            if ( Content == null )
            {
                SetVisiblePage ( name );
            }

            if ( PageAdded != null )
            {
                PageAdded.Invoke ( this, EventArgs.Empty );
            }
        }

        private sealed class StackPage
        {
            public string Name { get; set; }

            public string Title { get; set; }

            public Widget Widget { get; set; }
        }
    }
}

