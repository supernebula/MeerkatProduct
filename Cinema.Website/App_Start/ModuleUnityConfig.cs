﻿
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Evol.Common.Repository;
using Evol.Domain;
using Evol.Domain.Configuration;
using Evol.Domain.Messaging;
using Evol.EntityFramework.Repository;
using Unity.Mvc5;

namespace Cinema.Website
{
    public static class ModuleUnityConfig
    {
        public static void RegisterModuleComponents()
        {
            AppConfiguration.Current.InitModuleFrom<CinemaWebsiteModule>();
            AppConfiguration.Current.Container.RegisterType<IDbContextFactory, DefualtDbContextFactory>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IActiveUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IActiveUnitOfWork, EfUnitOfWork>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandBus, CommandBus>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<IUserSession, UserSession>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandHandlerFactory, DefaultCommandHandlerFactory>(new PerThreadLifetimeManager());
            AppConfiguration.Current.Container.RegisterType<ICommandHandlerActivator, DefaultCommandHandlerFactory.DefaultCommandHandlerActivator>(new PerThreadLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(AppConfiguration.Current.Container));
        }
    }
}