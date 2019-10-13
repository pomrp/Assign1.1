using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assign1._1.Startup))]
namespace Assign1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
