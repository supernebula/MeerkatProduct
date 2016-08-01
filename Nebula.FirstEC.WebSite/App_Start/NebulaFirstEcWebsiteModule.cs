﻿using System;
using System.Reflection;
using Nebula.Domain.Modules;
using Nebula.FirstEC.Data;
using Nebula.FirstEC.Domain;

namespace Nebula.FirstEC.Website
{
    [DependOn(typeof(NebulaFirstEcDataModule), typeof(NebulaFirstEcDomainModule))]
    public class NebulaFirstEcWebsiteModule : AppModule
    {
        public override void Initailize()
        {
            InitDependModule();
            base.Initailize();
        }

        private void InitDependModule()
        {
            var moduleTypes = this.FindDependModuleTypes(typeof(NebulaFirstEcWebsiteModule));
            foreach (var type in moduleTypes)
            {
                var constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.HasThis, new Type[] { }, null);
                var moduleObj = (AppModule)constructorInfo.Invoke(new object[] { });
                moduleObj.Initailize();
            }
        }
    }
}