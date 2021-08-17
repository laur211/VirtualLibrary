using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualLibrary.Startup))]
namespace VirtualLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
