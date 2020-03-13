using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonashLTS.Startup))]
namespace MonashLTS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
