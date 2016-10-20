using System.Reflection;
using Evol.FirstEC.Data.Ioc;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;
using Evol.FirstEC.Domain;

namespace Evol.FirstEC.Data
{
    [DependOn(typeof(EvolFirstEcDomainModule))]
    public class EvolFirstEcDataModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public EvolFirstEcDataModule()
        {
            _dataDependencyRegister = new DataConventionalDependencyRegister();
        }

        public override void Initailize()
        {
            _dataDependencyRegister.Register(IoCManager.Container, Assembly.GetExecutingAssembly());
            base.Initailize();
        }
    }
}
