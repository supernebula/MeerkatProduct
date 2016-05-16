using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Utilities;

namespace Nebula.FirstEC.Compoment
{
    public interface IEntity : IPrimaryKey, IMarkDelete
    {
        DateTime CreateDate { get; set; }
    }
}
