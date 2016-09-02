﻿using System.Reflection;
using Nebula.Cinema.Data.Ioc;
using Nebula.Cinema.Domain;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;

namespace Nebula.Cinema.Data
{
    [DependOn(typeof(CinemaDomainModule))]
    public class CinemaDataModule : AppModule
    {
        private readonly IConventionalDependencyRegister _dataDependencyRegister;

        public CinemaDataModule()
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
