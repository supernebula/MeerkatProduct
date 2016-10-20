using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.Cinema.Domain.CommandHandlers;
using Evol.Cinema.Domain.Commands;
using Evol.Domain;
using Evol.Domain.Configuration;
using Evol.Domain.Messaging;
using Evol.FirstEC.Website;

namespace Evol.First.WebSite.Tests.Modules
{
    [TestClass]
    public class ModuleTest
    {
        [TestMethod]
        public void AppModuleInitTest()
        {
            var registrations1 = AppConfiguration.Current.Container.Registrations.Count();
            var webModule = new EvolFirstEcWebsiteModule();
            webModule.Initailize();
            var registrations2 = AppConfiguration.Current.Container.Registrations.Count();
            Trace.WriteLine($"注册前：{registrations1}，注册后{registrations2}");

            var handler = AppConfiguration.Current.Container.Resolve<ICommandHandler<MovieCreateCommand>>();
            Trace.WriteLine(handler.GetType().FullName);
        }
    }
}
