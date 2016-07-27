﻿using System;
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
