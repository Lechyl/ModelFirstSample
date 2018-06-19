using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCNovels.Startup))]
namespace MVCNovels
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
