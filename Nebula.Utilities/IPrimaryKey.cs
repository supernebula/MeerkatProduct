using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities
{
    public interface IPrimaryKey
    {
        Guid Id { get; set; }
    }
}
