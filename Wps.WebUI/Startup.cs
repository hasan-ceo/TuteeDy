using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wps.WebUI.Startup))]
namespace Wps.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
