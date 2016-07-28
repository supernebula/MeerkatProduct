using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;

namespace Nebula.Cinema.Domain
{
    public class NebulaCinemaDomainModule : AppModule
    {
        private readonly IConventionalDependencyRegister _domainDependencyRegister;

        public NebulaCinemaDomainModule()
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
