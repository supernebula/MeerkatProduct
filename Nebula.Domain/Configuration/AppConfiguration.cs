using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Nebula.Domain.Configuration
{
    public class AppConfiguration
    {

        public DependencyConfiguration DependencyConfiguration { get; private set; }

        private static AppConfiguration _current = new AppConfiguration();

        public static AppConfiguration Current => _current;

        public AppConfiguration()
        {
            DependencyConfiguration = new DependencyConfiguration();
        }
    }
}
