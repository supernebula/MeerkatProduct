﻿using Evol.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogExceptionAttribute());
        }
    }
}
