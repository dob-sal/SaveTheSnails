using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaveTheSnails.Web.Startup))]
namespace SaveTheSnails.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
