using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Domain.Configuration
{
    public class DependencyResolver : IDependencyResolver
    {
        public static IDependencyResolver Current;

        public object GetInstance(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
