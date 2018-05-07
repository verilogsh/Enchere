using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Enchere.Startup))]
namespace Enchere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
