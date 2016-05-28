using System.Collections.Generic;

namespace Nebula.Common
{
    public interface IPaged<out T> : IPaged, IEnumerable<T>
    {
    }


    public interface IPaged
    {
        int PageCount { get; }
        int RecordCount { get; }

        int Index { get; }

        int Size { get; }

    }
}
