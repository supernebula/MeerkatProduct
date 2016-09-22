using System.Collections;
using System.Collections.Generic;

namespace Nebula.Common
{
    public interface IPaged<out T> : IPaged, IEnumerable<T>, IEnumerable
    {
    }


    public interface IPaged
    {
        int PageTotal { get; }
        int RecordTotal { get; }

        int Index { get; }

        int Size { get; }

    }
}
