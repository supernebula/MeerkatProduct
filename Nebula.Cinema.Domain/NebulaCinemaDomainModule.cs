using System.Reflection;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;

namespace Nebula.Cinema.Domain
{
    public class NebulaCinemaDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public NebulaCinemaDomainModule()
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
