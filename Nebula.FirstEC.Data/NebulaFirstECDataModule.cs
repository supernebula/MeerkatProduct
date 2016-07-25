using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.FirstEC.Data.Ioc;
using Nebula.Utilities;
using Nebula.Utilities.Ioc;

namespace Nebula.FirstEC.Data
{
    public class NebulaFirstEcDataModule : AppModule
    {
        private IConventionalDependencyRegister _dependencyRegister;
        private IUnityContainer _container;

        public NebulaFirstEcDataModule()
        {
            _dependencyRegister = new DataConventionalDependencyRegister();
            //_container = AppConfiguration.Container;
        }

        public override void Initailize()
        {
            _dependencyRegister.Register(_container, Assembly.GetExecutingAssembly());
            
            base.Initailize();
        }
    }
}
