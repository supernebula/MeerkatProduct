using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nebula.Common;

namespace Nebula.Utilities
{
    public class IoCUtility
    {
        public static List<InterfaceImplPair> GetInterfaceAndClass(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new NullReferenceException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new NullReferenceException(nameof(classNamespace));
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));
            if (assemblies.Length == 0)
                throw new ArgumentException(nameof(assemblies) + ".Length is 0");

            //load assembly
            //List<Type> types = new List<Type>();
            //assemblies.ToList().ForEach(assem =>
            //{
            //    types.AddRange(assem.GetTypes());
            //});

            var interfaces  = FindTypeOfNamespace(interfaceNamespace, true, assemblies).Where(t => t.IsPublic).ToList();



            //finds all interface with in specity namespaces
            //var interfaces = types.Where(t => t.IsPublic && t.IsInterface && t.Namespace == interfaceNamespace).ToList();
            //finds all implementClass of interface with in assembly
            //var impls = types.Where(t => t.IsClass && t.IsPublic && t.Namespace == classNamespace && t.GetInterfaces().Length > 0).ToList();
            var impls = FindTypeOfNamespace(classNamespace, false, assemblies).Where(t => t.IsClass && t.IsPublic && t.Namespace == classNamespace && t.GetInterfaces().Length > 0).ToList();

            var interfClassPairs = new List<InterfaceImplPair>();
            interfaces.ForEach(i =>
            {
                var @class = impls.FirstOrDefault(t => t.GetInterfaces().Select(e => e.FullName).Contains(i.FullName));
                if (@class != null)
                    interfClassPairs.Add(new InterfaceImplPair { Interface = i, Impl = @class });
            });
            return interfClassPairs;
        }

        public static List<Type> FindTypeOfNamespace(string @namespace, bool isInterface, params Assembly[] assemblies)
        {
            List<Type> types = new List<Type>();
            assemblies.ToList().ForEach(assem =>
            {
                types.AddRange(assem.GetTypes());
            });

            types = types.Where(t => t.Namespace == @namespace).ToList();

            if (isInterface)
                types = types.Where(t => t.IsInterface).ToList();
            return types;
        }

        public List<Type> FindSpecifyTypes(Func<Type, bool>  filter, Assembly assembly)
        {
            return assembly.GetTypes().Where(filter).ToList();
        }

    }
}
