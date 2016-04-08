using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeletieneDPS.Startup))]
namespace SeletieneDPS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
