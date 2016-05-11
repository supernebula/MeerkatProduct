using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Nebula.First.Business;
using Nebula.First.Data;
using Nebula.First.Data.EntityQueries;
using Nebula.First.DataStorage;
using Nebula.First.DataStorage.EntityQueries;

namespace Nebula.First.MobileSite
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductEntityQuery, ProductEntityQuery>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}