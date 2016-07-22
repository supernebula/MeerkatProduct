using System;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Utilities.Test
{
    [TestClass]
    public class IoCUtilityTes
    {
        [TestMethod]
        public void GetInterfaceAndClassFromAssemblyTest()
        {
            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass(
                    "Nebula.FirstEC.Domain.Repositories"
                    , "Nebula.FirstEC.Data.Repositories"
                    , Assembly.Load("Nebula.FirstEC.Domain")
                    , Assembly.Load("Nebula.FirstEC.Data")
                );
            
            interfaceClassPaires.ForEach(p => Trace.WriteLine(p.Interface.FullName + "\r\n : " + p.Impl.FullName));
        }
    }
}
