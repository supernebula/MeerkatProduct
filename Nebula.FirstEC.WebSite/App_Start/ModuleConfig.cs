using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nebula.FirstEC.Website
{
    public class ModuleConfig
    {
        public void Config()
        {
            var webModule = new NebulaFirstEcWebsiteModule();
            webModule.Initailize();
        }
    }
}