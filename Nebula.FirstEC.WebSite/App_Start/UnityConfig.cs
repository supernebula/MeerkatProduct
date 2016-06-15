using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Nebula.Common.Repository;
using Nebula.EntityFramework.Repository;
using Unity.Mvc5;
using Nebula.FirstEC.Domain.Repositories;
using Nebula.FirstEC.Data.Repositories;

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
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            // Register more type IRepository....

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}