using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nebula.First.WebSite.Startup))]
namespace Nebula.First.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
