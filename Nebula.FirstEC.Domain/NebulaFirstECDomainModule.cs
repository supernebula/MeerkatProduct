using System;
using Nebula.Domain.Modules;


namespace Nebula.FirstEC.Domain
{
    public class NebulaFirstEcDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dependencyRegister;

        public NebulaFirstEcDataModule()
        {
            _dependencyRegister = new DataConventionalDependencyRegister();

        }

        public override void Initailize()
        {
            _dependencyRegister.Register(IoCManager.Container, Assembly.GetExecutingAssembly());
            base.Initailize();
        }
    }
}
