//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Nebula.Domain.Ioc;
//using Nebula.Utilities.Modules;

//namespace Nebula.Utilities
//{
//    public abstract class AppModule
//    {
//        public IIoCManager IoCManager;

//        public virtual void Initailize()
//        {
//        }

//        public bool IsAppModule(Type type)
//        {
//            return type.IsPublic && type.IsClass && typeof (AppModule).IsAssignableFrom(type);
//        }

//        public List<Type> FindDependModuleTypes(Type moduleType)
//        {
//            if(moduleType == null)
//                throw new ArgumentNullException(nameof(moduleType));
//            if(!IsAppModule(moduleType))
//                throw new ArgumentException($"参数{nameof(moduleType)}的类型{moduleType.FullName}不是{nameof(AppModule)}或其派生类");

//            var list = new List<Type>();
//            if(!moduleType.IsDefined(typeof(DependOnAttribute), true))
//                return list;
//            var attributes = moduleType.GetCustomAttributes(typeof(DependOnAttribute), true).Cast<DependOnAttribute>();
            
//            foreach (var attr in attributes)
//            {
//                list.AddRange(attr.DependedModuleTypes);
//            }
//            return list;
//        }
//    }
//}
