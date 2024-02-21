using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyIdent.Startup))]
namespace MyIdent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
