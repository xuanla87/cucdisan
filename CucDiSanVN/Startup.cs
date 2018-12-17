using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CucDiSanVN.Startup))]
namespace CucDiSanVN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
