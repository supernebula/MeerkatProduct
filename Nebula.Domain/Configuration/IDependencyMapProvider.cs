using System.Collections.Generic;
using System.Reflection;
using Nebula.Common;

namespace Nebula.Domain.Configuration
{
    public interface IDependencyMapProvider
    {
        IEnumerable<InterfaceClassPair> GetDependencyMap(params Assembly[] assemblies);
    }
}
