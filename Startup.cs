using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JayAns.Startup))]
namespace JayAns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
