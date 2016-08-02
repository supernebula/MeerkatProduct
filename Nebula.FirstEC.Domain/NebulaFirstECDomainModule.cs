using System;
using System.Reflection;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;
using Nebula.FirstEC.Domain.Modules;


namespace Nebula.FirstEC.Domain
{
    public class NebulaFirstEcDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public NebulaFirstEcDomainModule()
        {
            _domainDependencyRegister = new DomainConventionalDependencyRegister();

        }

        public override void Initailize()
        {
            _domainDependencyRegister.Register(IoCManager.Container, Assembly.GetExecutingAssembly());
            base.Initailize();
        }
    }
}
