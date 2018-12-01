using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeTastic.Startup))]
namespace RecipeTastic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
