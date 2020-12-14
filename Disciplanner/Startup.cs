using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Disciplanner.Startup))]
namespace Disciplanner
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
