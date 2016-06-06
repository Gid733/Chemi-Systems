using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChemiSystems.Startup))]
namespace ChemiSystems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
