using System.Web.Mvc;
using System.Reflection;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Nebula.Utilities;

namespace Nebula.FirstEC.WebSite
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass(
                "Nebula.FirstEC.Domain.QueryEntries"
                ,"Nebula.FirstEC.Data"
                , Assembly.Load("Nebula.FirstEC.Domain")
                , Assembly.Load("Nebula.FirstEC.Data"));
            interfaceClassPaires.ForEach(p => container.RegisterType(p.InterfaceType, p.ClassType, new PerThreadLifetimeManager()));
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}