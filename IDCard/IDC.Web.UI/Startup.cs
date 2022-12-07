using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IDC.Web.UI.Startup))]
namespace IDC.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
