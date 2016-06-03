using System;
using System.Collections.Generic;
using System.Linq;
using Xwt;

namespace Fontify
{
    public class SimpleListDataSource : IListDataSource
    {
        private IEnumerable<String> enumerable;

        public SimpleListDataSource ( IEnumerable<String> enumerable )
        {
            if ( enumerable == null )
            {
                throw new ArgumentNullException ();
            }

            this.enumerable = enumerable;
        }

        #region IListDataSource implementation

        public event EventHandler<ListRowEventArgs> RowInserted;

        public event EventHandler<ListRowEventArgs> RowDeleted;

        public event EventHandler<ListRowEventArgs> RowChanged;

        public event EventHandler<ListRowOrderEventArgs> RowsReordered;

        public object GetValue ( int row, int column )
        {
            return enumerable.ElementAt ( row );
        }

        public void SetValue ( int row, int column, object value )
        {
            throw new NotImplementedException ();
        }

        public int RowCount
        {
            get
            {
                return enumerable.Count ();
            }
        }

        public Type[] ColumnTypes
        {
            get
            {
                return new Type[] { typeof ( string ) };
            }
        }

        #endregion
    }
}

