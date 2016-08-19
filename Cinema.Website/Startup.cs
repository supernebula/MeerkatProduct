using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinema.Website.Startup))]
namespace Cinema.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
