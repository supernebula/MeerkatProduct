using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Nebula.Domain.Configuration
{
    public class DependencyConfiguration
    {
        public static DependencyConfiguration Current;

        public IUnityContainer UnityContainer { get; set; }
    }
}
