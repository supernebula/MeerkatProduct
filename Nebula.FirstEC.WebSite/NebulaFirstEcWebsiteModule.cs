using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nebula.Utilities;

namespace Nebula.FirstEC.Website
{
    public class NebulaFirstEcWebsiteModule : AppModule
    {
        public override void Initailize()
        {
            IocRegister();
            base.Initailize();
        }

        private void IocRegister()
        {
                
        }
    }
}