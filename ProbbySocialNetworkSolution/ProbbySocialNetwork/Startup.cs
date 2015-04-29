using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProbbySocialNetwork.Startup))]
namespace ProbbySocialNetwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
