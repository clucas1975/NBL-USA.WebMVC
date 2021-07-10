using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NBL_USA.WebMVC.Startup))]
namespace NBL_USA.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
