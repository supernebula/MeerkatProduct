using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Nebula.Domain.Configuration
{
    public class AppConfiguration
    {

        public DependencyConfiguration DependencyConfiguration { get; private set; }

        private static AppConfiguration _current;

        public static AppConfiguration Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new AppConfiguration();
                    _current.Init();
                }
                return _current;
            }
        }

        public AppConfiguration()
        {
            IUnityContainer unityContainer = new UnityContainer();
            DependencyConfiguration = new DependencyConfiguration(unityContainer);
            DependencyConfiguration.Init();
        }

        public void Init()
        {

        }

    }
}
