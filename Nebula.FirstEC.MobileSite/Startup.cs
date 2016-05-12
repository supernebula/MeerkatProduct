using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nebula.FirstEC.MobileSite.Startup))]
namespace Nebula.FirstEC.MobileSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
