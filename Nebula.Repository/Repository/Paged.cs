using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Repository
{
    public class Paged<T> : List<T>, IPaged<T>
    {
        public int PageCount { set; get; }

        public int RecordCount { set; get; }

        public int Index { set; get; }

        public int Size { set; get; }
    }
}
