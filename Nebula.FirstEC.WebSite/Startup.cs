using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nebula.FirstEC.WebSite.Startup))]
namespace Nebula.FirstEC.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
