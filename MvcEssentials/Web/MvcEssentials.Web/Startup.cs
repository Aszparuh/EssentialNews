using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcEssentials.Web.Startup))]

namespace MvcEssentials.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
