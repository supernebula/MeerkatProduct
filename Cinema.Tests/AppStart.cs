using Microsoft.Practices.Unity;
using Cinema.Website;
using Nebula.Common.Repository;
using Nebula.Domain;
using Nebula.Domain.Messaging;
using Nebula.EntityFramework.Repository;

namespace Cinema.Tests
{
    public static class AppStart
    {
        public static void Init()
        {
            AppConfiguration.Current.InitModule<CinemaWebsiteModule>();
            AppConfiguration.Current.Container.RegisterType<IDbContextFactory, DefualtDbContextFactory>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IActiveUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandBus, CommandBus>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandHandlerFactory, DefaultCommandHandlerFactory>(new PerThreadLifetimeManager());
        }
    }
}
