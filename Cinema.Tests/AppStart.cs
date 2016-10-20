using Microsoft.Practices.Unity;
using Cinema.Website;
using Evol.Common.Repository;
using Evol.Domain;
using Evol.Domain.Messaging;
using Evol.EntityFramework.Repository;

namespace Cinema.Tests
{
    public static class AppStart
    {
        public static void Init()
        {
            AppConfiguration.Current.InitModuleFrom<CinemaWebsiteModule>();
            AppConfiguration.Current.Container.RegisterType<IDbContextFactory, DefualtDbContextFactory>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IActiveUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandBus, CommandBus>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandHandlerFactory, DefaultCommandHandlerFactory>(new PerThreadLifetimeManager());
        }
    }
}
