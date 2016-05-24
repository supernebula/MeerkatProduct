using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Common
{
    public interface IPrimaryKey
    {
        Guid Id { get; set; }
    }
}
