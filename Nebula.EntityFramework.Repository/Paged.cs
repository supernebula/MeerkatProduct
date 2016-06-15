using System;
using System.Collections.Generic;
using Nebula.Common;

namespace Nebula.EntityFramework.Repository
{
    public class Paged<T> : List<T>, IPaged<T>
    {
        public Paged(IEnumerable<T> items, int pageIndex, int pageSize)
        {
            this.AddRange(items);
            Index = pageIndex;
            Size = pageSize;
        }
        public int Index { get; private set; }

        public int PageCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public int RecordCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Size { get; private set; }
    }
}
