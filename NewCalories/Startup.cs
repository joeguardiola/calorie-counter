using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewCalories.Startup))]
namespace NewCalories
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
