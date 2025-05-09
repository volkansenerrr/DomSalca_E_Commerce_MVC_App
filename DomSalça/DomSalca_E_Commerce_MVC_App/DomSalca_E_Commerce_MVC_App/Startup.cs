using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DomSalca_E_Commerce_MVC_App.Startup))]
namespace DomSalca_E_Commerce_MVC_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
