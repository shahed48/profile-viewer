using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProfileViewer.Startup))]
namespace ProfileViewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
