using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(fabrikafoodService.Startup))]

namespace fabrikafoodService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}