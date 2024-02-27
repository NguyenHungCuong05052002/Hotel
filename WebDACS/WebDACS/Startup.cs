using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDACS.Startup))]
namespace WebDACS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
