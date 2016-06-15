using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Nebula.Common.Repository;
using Nebula.EntityFramework.Repository;
using Unity.Mvc5;

namespace Nebula.FirstEC.WebSite
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IUnitOfWork), typeof(UnitOfWork<>), new PerThreadLifetimeManager());
            container.RegisterType(typeof(IDbContextFactory<>), typeof(EfDbContextFactory<>), new PerThreadLifetimeManager());
            //container.RegisterType<IProductService, ProductService>();
            //container.RegisterType<IProductEntityQuery, ProductEntityQuery>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}