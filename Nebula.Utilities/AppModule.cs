using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities
{
    public abstract class AppModule
    {
        public virtual void Initailize()
        {

        }

        public bool IsAppModule(Type type)
        {
            throw new NotImplementedException();
        }

        public List<Type> FindDependModuleTypes(Type moduleType)
        {
            throw new NotImplementedException();
        }
    }
}
