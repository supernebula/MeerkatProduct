using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Cinema.Domain.CommandHandlers;
using Nebula.Cinema.Domain.Commands;
using Nebula.Domain;
using Nebula.Domain.Configuration;
using Nebula.Domain.Messaging;
using Nebula.FirstEC.Website;

namespace Nebula.First.WebSite.Tests.Modules
{
    [TestClass]
    public class ModuleTest
    {
        [TestMethod]
        public void AppModuleInitTest()
        {
            var registrations1 = AppConfiguration.Current.Container.Registrations.Count();
            var webModule = new NebulaFirstEcWebsiteModule();
            webModule.Initailize();
            var registrations2 = AppConfiguration.Current.Container.Registrations.Count();
            Trace.WriteLine($"注册前：{registrations1}，注册后{registrations2}");

            var handler = AppConfiguration.Current.Container.Resolve<ICommandHandler<MovieCreateCommand>>();
            Trace.WriteLine(handler.GetType().FullName);
        }
    }
}
