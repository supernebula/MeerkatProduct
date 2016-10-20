using System;
using System.Reflection;
using Evol.Domain.Modules;
using Evol.FirstEC.Data;
using Evol.FirstEC.Domain;
using Evol.Cinema.Domain;

namespace Evol.FirstEC.Website
{
    [DependOn(typeof(EvolFirstEcDataModule), typeof(EvolFirstEcDomainModule), typeof(CinemaDomainModule))]
    public class EvolFirstEcWebsiteModule : AppModule
    {
        public override void Initailize()
        {
            InitDependModule<EvolFirstEcWebsiteModule>();
            base.Initailize();
        }

        //private void InitDependModule()
        //{
        //    var moduleTypes = this.FindDependModuleTypes(typeof(EvolFirstEcWebsiteModule));
        //    foreach (var type in moduleTypes)
        //    {
        //        var constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.HasThis, new Type[] { }, null);
        //        var moduleObj = (AppModule)constructorInfo.Invoke(new object[] { });
        //        moduleObj.Initailize();
        //    }
        //}
    }
}