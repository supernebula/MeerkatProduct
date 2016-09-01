using System.Web.Mvc;
using System.Reflection;
using Microsoft.Practices.Unity;
using Nebula.Domain.Configuration;
using Nebula.Domain.Messaging;
using Nebula.FirstEC.Domain.QueryEntries;
using Unity.Mvc5;
using Nebula.Utilities;

namespace Nebula.FirstEC.WebSite
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
            //DependencyConfiguration.RegisterMessagingComponents("Nebula.FirstEC.Domain");
            //DependencyConfiguration.RegisterRepository("Nebula.FirstEC.Domain.Repositories", "Nebula.FirstEC.Data.Repositories", "Nebula.FirstEC.Domain", "Nebula.FirstEC.Data");
            //DependencyConfiguration.RegisterQueryEntry("Nebula.FirstEC.Domain.QueryEntries", "Nebula.FirstEC.Data.QueryEntries", "Nebula.FirstEC.Domain", "Nebula.FirstEC.Data");
            //// e.g. container.RegisterType<ITestService, TestService>();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //DependencyResolver.SetResolver(DependencyConfiguration.DependencyResolver);
        }
    }
}