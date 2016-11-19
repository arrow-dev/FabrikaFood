using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FabrikaFoodBackend.Startup))]

namespace FabrikaFoodBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}