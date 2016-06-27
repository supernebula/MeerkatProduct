using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Domain.Configuration
{
    public interface IDependencyResolver
    {
        object GetInstance(Type type);
    }
}
