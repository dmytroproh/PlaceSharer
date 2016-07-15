using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using PlaceSharer.BLL.Services;
using PlaceSharer.BLL.Interfaces;

[assembly: OwinStartup(typeof(PlaceSharer.WEB.App_Start.Startup))]

namespace PlaceSharer.WEB.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.CreatePerOwinContext<IPlaceService>(CreatePlaceService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            //app.UseFacebookAuthentication(
            //  appId: "639310519553746",
            //  appSecret: "c4dceb51dcdbf0a707b0593da662b7ee");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "931263474066-fq72bkgurb1alnsnknedrrcvk6mhtviu.apps.googleusercontent.com",
            //    ClientSecret = "_xPF6a3OKZ-VYGPNltu9tFAb"
            //});
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }

        private IPlaceService CreatePlaceService()
        {
            return serviceCreator.CreatePlaceService("DefaultConnection");
        }
    }
}
