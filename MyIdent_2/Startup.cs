using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyIdent_2.Startup))]
namespace MyIdent_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
