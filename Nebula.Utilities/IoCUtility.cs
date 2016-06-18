using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Nebula.Utilities
{
    public struct InterfaceClassPair
    {
        public Type InterfaceType { get; set; }

        public Type ClassType { get; set; }
    }

    public class IoCUtility
    {
        public static List<InterfaceClassPair> GetInterfaceAndClass(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new NullReferenceException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new NullReferenceException(nameof(classNamespace));
            if (assemblies.Length == 0)
                throw new ArgumentNullException(nameof(assemblies));

            //load assembly
            List<Type> types = new List<Type>();
            assemblies.ToList().ForEach(assem =>
            {
                types.AddRange(assem.GetTypes());
            });

            //finds all interface with in specity namespaces
            var interfaces = types.Where(t => t.IsPublic && t.IsInterface && t.Namespace == interfaceNamespace).ToList();
            //finds all implementClass of interface with in assembly
            var possibleClasses = types.Where(t => t.IsClass && t.IsPublic && t.Namespace == classNamespace && t.GetInterfaces().Length > 0).ToList();

            var interfClassPairs = new List<InterfaceClassPair>();
            interfaces.ForEach(i =>
            {
                var @class = possibleClasses.FirstOrDefault(t => t.GetInterfaces().Select(e => e.FullName).Contains(i.FullName));
                if (@class != null)
                    interfClassPairs.Add(new InterfaceClassPair { InterfaceType = i, ClassType = @class });
            });

#if DEBUG
            Debug.WriteLine("Interface Total:" + interfaces.Count);
            Debug.WriteLine("Interface-ImplementClass Total:" + interfClassPairs.Count);
            interfClassPairs.ForEach(e => Debug.WriteLine(e.InterfaceType.FullName + " - " + e.ClassType.FullName));
#endif
            return interfClassPairs;
        }
    }
}
