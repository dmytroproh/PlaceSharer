using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using PlaceSharer.BLL.Services;
using PlaceSharer.BLL.Interfaces;
using System;

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
