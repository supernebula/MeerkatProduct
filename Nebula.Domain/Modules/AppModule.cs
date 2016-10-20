﻿using System;
using System.Collections.Generic;
using System.Linq;
using Evol.Domain.Ioc;
using System.Reflection;

namespace Evol.Domain.Modules
{
    /// <summary>
    /// 模型（目前每个项目看作一个模块）初始化
    /// </summary>
    public abstract class AppModule
    {

        /// <summary>
        /// 管理依赖注入
        /// </summary>
        public IIoCManager IoCManager;

        protected AppModule()
        {
            IoCManager = AppConfiguration.Current.IoCManager;
        }

        public virtual void Initailize()
        {
        }

        public bool IsAppModule(Type type)
        {
            return type.IsPublic && type.IsClass && typeof(AppModule).IsAssignableFrom(type);
        }

        public List<Type> FindDependModuleTypes(Type moduleType)
        {
            if (moduleType == null)
                throw new ArgumentNullException(nameof(moduleType));
            if (!IsAppModule(moduleType))
                throw new ArgumentException($"参数{nameof(moduleType)}的类型{moduleType.FullName}不是{nameof(AppModule)}或其派生类");

            var list = new List<Type>();
            if (!moduleType.IsDefined(typeof(DependOnAttribute), true))
                return list;
            var attributes = moduleType.GetCustomAttributes(typeof(DependOnAttribute), true).Cast<DependOnAttribute>();

            foreach (var attr in attributes)
            {
                list.AddRange(attr.DependedModuleTypes);
            }
            return list;
        }

        protected void InitDependModule<T>() where T :  AppModule, new()
        {
            var moduleTypes = this.FindDependModuleTypes(typeof(T));
            foreach (var type in moduleTypes)
            {
                var constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.HasThis, new Type[] { }, null);
                var moduleObj = (AppModule)constructorInfo.Invoke(new object[] { });
                moduleObj.Initailize();
            }
        }
    }
}
