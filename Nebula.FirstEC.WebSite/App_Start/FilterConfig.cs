using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nebula.Web.Filters;

namespace Nebula.FirstEC.WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection collection)
        {
            collection.Add(new WebExceptionFilterAttribute());
        }
    }
}
