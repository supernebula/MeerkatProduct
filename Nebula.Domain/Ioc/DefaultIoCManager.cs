﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Nebula.Domain.Ioc
{
    public class DefaultIoCManager : IIoCManager
    {
        public IUnityContainer Container { get; }

        public DefaultIoCManager(IUnityContainer container)
        {
            Container = container;
        }
    }
}