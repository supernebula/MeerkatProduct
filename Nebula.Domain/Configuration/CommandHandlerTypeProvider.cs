using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nebula.Common;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Configuration
{
    public class CommandHandlerTypeProvider : IDependencyMapProvider
    {
        private readonly Func<IEnumerable<Assembly>> _assembliesThunk;
        public CommandHandlerTypeProvider()
        {
            _assembliesThunk = () => new List<Assembly>() { Assembly.GetExecutingAssembly() };
        }

        public CommandHandlerTypeProvider(params Assembly[] assemblies)
        {
            if (assemblies.Any(e => e != null))
                throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
            _assembliesThunk = () => assemblies.Where(e => e != null);
        }

        public IEnumerable<InterfaceClassPair> GetDependencyMap()
        {
            var types = new List<Type>();
            _assembliesThunk().ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
            var result = types
                .Where( t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (ICommandHandler<>)))
                .Select(t => new InterfaceClassPair { InterfaceType = t.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), ClassType = t});
            return result.ToList();
        }
    }
}
