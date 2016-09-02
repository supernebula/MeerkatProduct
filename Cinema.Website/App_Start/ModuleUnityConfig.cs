
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Nebula.Common.Repository;
using Nebula.Domain;
using Nebula.Domain.Messaging;
using Nebula.EntityFramework.Repository;
using Unity.Mvc5;

namespace Cinema.Website
{
    public static class ModuleUnityConfig
    {
        public static void RegisterModuleComponents()
        {
            AppConfiguration.Current.InitModule<CinemaWebsiteModule>();
            RegisterComponents();
        }

        public static void RegisterComponents()
        {
            //var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(AppConfiguration.Current.Container));
            AppConfiguration.Current.Container.RegisterType<ICommandBus, CommandBus>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IUserSession, UserSession>(new PerThreadLifetimeManager());
        }
    }
}