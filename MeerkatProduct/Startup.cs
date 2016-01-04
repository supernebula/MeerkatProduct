using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeerkatProduct.Startup))]
namespace MeerkatProduct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
