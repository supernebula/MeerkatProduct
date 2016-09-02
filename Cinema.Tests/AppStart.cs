using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Website;
using Nebula.Domain;

namespace Cinema.Tests
{
    public static class AppStart
    {
        public static void Init()
        {
            AppConfiguration.Current.InitModule<CinemaWebsiteModule>();
        }
    }
}
