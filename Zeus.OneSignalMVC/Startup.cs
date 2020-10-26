using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeus.OneSignalMVC.Startup))]
namespace Zeus.OneSignalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
