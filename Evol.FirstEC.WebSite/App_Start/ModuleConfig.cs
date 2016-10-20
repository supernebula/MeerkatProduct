using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evol.FirstEC.Website
{
    public class ModuleConfig
    {
        public void Config()
        {
            var webModule = new EvolFirstEcWebsiteModule();
            webModule.Initailize();
        }
    }
}