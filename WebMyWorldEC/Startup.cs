using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMyWorldEC.Startup))]
namespace WebMyWorldEC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
