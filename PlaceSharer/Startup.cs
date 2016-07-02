using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlaceSharer.Startup))]
namespace PlaceSharer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
