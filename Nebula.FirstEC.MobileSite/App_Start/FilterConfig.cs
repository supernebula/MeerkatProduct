using System.Web;
using System.Web.Mvc;

namespace Nebula.FirstEC.MobileSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
