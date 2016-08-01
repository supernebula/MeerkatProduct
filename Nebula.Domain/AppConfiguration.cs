using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Domain.Ioc;

namespace Nebula.Domain
{
    public class AppConfiguration
    {
        private IIoCManager _currentIoCManager;


        public IIoCManager IoCManager
        {
            get
            {
                if(_currentIoCManager == null)
                    _currentIoCManager = new DefaultIoCManager(this.Container);
                return _currentIoCManager;
            }
        }

        private IUnityContainer _container;

        public IUnityContainer Container
        {
            get
            {
                if (_container == null)
                    _container = new UnityContainer();
                return _container;
            }
        }

        private static AppConfiguration _current;
        public static AppConfiguration Current
        {
            get
            {
                if (_current == null)
                    _current = new AppConfiguration();
                return _current;
            }
        }

        public AppConfiguration()
        {


        }
    }
}
