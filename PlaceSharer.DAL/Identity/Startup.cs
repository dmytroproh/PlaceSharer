using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;

namespace PlaceSharer.DAL.Identity
{
    class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; set; }

        public void Configuration(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();

            
        }
    }
}
