using System;
using System.Reflection;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;


namespace Evol.FirstEC.Domain
{
    public class EvolFirstEcDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public EvolFirstEcDomainModule()
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
