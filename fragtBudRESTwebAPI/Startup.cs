using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fragtBudRESTwebAPI.Startup))]
namespace fragtBudRESTwebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
