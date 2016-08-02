using System.Collections.Generic;
using System.Reflection;
using Nebula.Common;

namespace Nebula.Domain.Configuration
{
    public interface IDependencyMapProvider
    {
        IEnumerable<InterfaceImplPair> GetDependencyMap(params Assembly[] assemblies);
    }
}
