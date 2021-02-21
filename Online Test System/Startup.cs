using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Test_System.Startup))]
namespace Online_Test_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
