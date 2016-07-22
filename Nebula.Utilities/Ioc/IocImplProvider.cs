using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common;

namespace Nebula.Utilities.Ioc
{
    public interface IIocImplProvider
    {
        List<InterfaceImplPair> Filter(Assembly assembly);
    }
}
