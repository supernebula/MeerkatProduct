using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Repository
{
    public interface IPaged<T> : IPaged, IEnumerable<T>
    {
    }


    public interface IPaged
    {
        int PageCount { get; set; }
        int RecordCount { get; set; }

        int Index { get; set; }

        int Size { get; set; }

    }
}
