using System;
using System.Data.Entity.Infrastructure;
using Nebula.FirstEC.WebSite.Core;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Mvc;
using Nebula.Common.Repository;
using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Data.EntityQueries;
using Nebula.FirstEC.DataStorage.EntityQueries;
using IProductService = Nebula.FirstEC.Business.IProductService;
using ProductService = Nebula.FirstEC.Business.ProductService;

namespace Nebula.FirstEC.WebSite.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.LoadConfiguration();
            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.LoadConfiguration();
            container.RegisterType(typeof(IUnitOfWork), typeof(UnitOfWork<>), new PerThreadLifetimeManager());
            container.RegisterType(typeof(IDbContextFactory<>), typeof(EfDbContextFactory<>), new PerThreadLifetimeManager());
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductEntityQuery, ProductEntityQuery>();
        }
    }
}
