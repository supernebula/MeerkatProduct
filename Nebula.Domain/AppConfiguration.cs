using System;
using Microsoft.Practices.Unity;
using Nebula.Domain.Ioc;
using Nebula.Domain.Modules;

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

        public void InitModule<TEntry>() where TEntry : AppModule, new()
        {
            (new TEntry()).Initailize();
        }

        public AppConfiguration()
        {


        }

        public AppConfiguration Use<TFrom, TTo>(LifetimeManager life) where TTo : TFrom
        {
            throw new NotImplementedException();
            Container.RegisterType<TFrom, TTo>(life);
            return this;
        }

        public AppConfiguration Use(Type from, Type to, LifetimeManager life)
        {
            throw new NotImplementedException();
            return this;
        }

    }
}
