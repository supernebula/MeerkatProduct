using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities
{
    public interface IPaged<T> : IPaged, IEnumerable<T>
    {
    }


    public interface IPaged
    {
        int PageCount { get; }
        int RecordCount { get;}

        int Index { get; }

        int Size { get; }

    }
}
