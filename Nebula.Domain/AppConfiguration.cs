using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Domain.Ioc;

namespace Nebula.Domain
{
    public class AppConfiguration
    {
        private IIoCManager _currentIoCManager;


        public IIoCManager CurrentIoCManager
        {
            get
            {
                if(_currentIoCManager == null)
                    _currentIoCManager = new DefaultIoCManager(null);
                return _currentIoCManager;
            }
        }

        public AppConfiguration()
        {


        }
    }
}
