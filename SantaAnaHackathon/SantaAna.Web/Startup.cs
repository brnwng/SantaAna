using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SantaAna.Web.Startup))]
namespace SantaAna.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
