using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Ioc
{
    public interface IConventionalDependencyRegister
    {
        void Register(IUnityContainer container, Assembly assembly);
    }
}
