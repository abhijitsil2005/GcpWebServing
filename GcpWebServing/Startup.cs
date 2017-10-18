using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GcpWebServing.Startup))]
namespace GcpWebServing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
