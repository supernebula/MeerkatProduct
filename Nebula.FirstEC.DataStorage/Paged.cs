using System;
using System.Collections.Generic;
using Nebula.Common;

namespace Nebula.FirstEC.DataStorage
{
    public class Paged<T> : List<T>, IPaged<T>
    {
        public int PageCount { set; get; }

        public int RecordCount { set; get; }

        public int Index { set; get; }

        public int Size { set; get; }
    }
}
