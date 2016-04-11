using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gep13.Cake.Sample.WebApplication.Startup))]
namespace Gep13.Cake.Sample.WebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
