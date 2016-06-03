using System;
using System.Collections.Generic;
using System.Linq;
using Xwt;

namespace Fontify
{
    public class Stack : Widget
    {
        private IDictionary<string, StackChild> children;

        public event EventHandler ChildAdded;
        public event EventHandler ChildRemoved;

        public Stack ()
        {
        }

        private string visibleChildName;

        public Widget VisibleChild
        {
            get
            { 
                return children[visibleChildName].Widget;
            }
        }

        public void SetVisibleChild ( string name )
        {
            if ( !children.ContainsKey ( name ) )
            {
                throw new ArgumentException ();
            }

            visibleChildName = name;
            Content = children[name].Widget;
        }

        public string GetVisibleChildName ()
        {
            return visibleChildName;
        }

        public string[] Names
        {
            get
            {
                return children.Values.Select ( _ => _.Name ).ToArray ();
            }
        }


        public string[] Titles
        {
            get
            {
                return children.Values.Select ( _ => _.Title ).ToArray ();
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
            children.Remove ( name );
            if ( ChildRemoved != null )
            {
                ChildRemoved.Invoke ( this, EventArgs.Empty );
            }
        }

        private void addChild ( Widget widget, string name, string title = "" )
        {

            if ( children == null )
            {
                children = new SortedDictionary<string, StackChild> ();
            }

            var child = new StackChild (){ Name = name, Title = title, Widget = widget };

            children.Add ( name, child );

            if ( Content == null )
            {
                SetVisibleChild ( name );
            }

            if ( ChildAdded != null )
            {
                ChildAdded.Invoke ( this, EventArgs.Empty );
            }
        }

        private sealed class StackChild
        {
            public string Name { get; internal set; }

            public string Title { get; internal set; }

            public Widget Widget { get; internal set; }
        }
    }
}

