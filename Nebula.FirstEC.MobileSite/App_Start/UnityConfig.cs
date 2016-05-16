using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.InteropServices;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Nebula.EntityFramework.Repository;
using Unity.WebApi;
using Nebula.FirstEC.Business;
using Nebula.FirstEC.Data.EntityQueries;
using Nebula.FirstEC.DataStorage.EntityQueries;

namespace Nebula.FirstEC.MobileSite
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
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductEntityQuery, ProductEntityQuery>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}