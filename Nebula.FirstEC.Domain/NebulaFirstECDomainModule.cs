using System;
using System.Reflection;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;


namespace Nebula.FirstEC.Domain
{
    public class NebulaFirstEcDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public NebulaFirstEcDomainModule()
        {
            _domainDependencyRegister = new DefualtDomainConventionalDependencyRegister();

        }

        public override void Initailize()
        {
            _domainDependencyRegister.Register(IoCManager.Container, Assembly.GetExecutingAssembly());
            base.Initailize();
        }
    }
}
