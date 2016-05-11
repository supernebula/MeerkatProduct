using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nebula.First.MobileSite.Startup))]
namespace Nebula.First.MobileSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
