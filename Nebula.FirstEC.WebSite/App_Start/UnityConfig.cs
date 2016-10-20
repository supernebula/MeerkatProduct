using System.Web.Mvc;
using System.Reflection;
using Microsoft.Practices.Unity;
using Evol.Domain.Configuration;
using Evol.Domain.Messaging;
using Evol.FirstEC.Domain.QueryEntries;
using Unity.Mvc5;
using Evol.Utilities;

namespace Evol.FirstEC.WebSite
{
    public static class UnityConfig
    {
        //public static DependencyConfiguration DependencyConfiguration => AppConfiguration.Current.DependencyConfiguration;

        public static void RegisterComponents()
        {
            ////var container = new UnityContainer();

            //// register all your components with the container here
            //// it is NOT necessary to register your controllers
            //DependencyConfiguration.RegisterCommandBus<CommandBus>();
            //DependencyConfiguration.RegisterEventBus<EventBus>();
            //DependencyConfiguration.RegisterMessagingComponents("Evol.FirstEC.Domain");
            //DependencyConfiguration.RegisterRepository("Evol.FirstEC.Domain.Repositories", "Evol.FirstEC.Data.Repositories", "Evol.FirstEC.Domain", "Evol.FirstEC.Data");
            //DependencyConfiguration.RegisterQueryEntry("Evol.FirstEC.Domain.QueryEntries", "Evol.FirstEC.Data.QueryEntries", "Evol.FirstEC.Domain", "Evol.FirstEC.Data");
            //// e.g. container.RegisterType<ITestService, TestService>();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //DependencyResolver.SetResolver(DependencyConfiguration.DependencyResolver);
        }
    }
}