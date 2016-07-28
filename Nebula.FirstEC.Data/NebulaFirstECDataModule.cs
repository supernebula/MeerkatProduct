using System.Reflection;
using Nebula.FirstEC.Data.Ioc;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;
using Nebula.FirstEC.Domain;

namespace Nebula.FirstEC.Data
{
    [DependOn(typeof(NebulaFirstEcDomainModule))]
    public class NebulaFirstEcDataModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public NebulaFirstEcDataModule()
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
