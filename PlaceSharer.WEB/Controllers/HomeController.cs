using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PlaceSharer.BLL.Interfaces;
using PlaceSharer.WEB.Models;
using AutoMapper;

namespace PlaceSharer.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult UserSearch()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult UserSearch(string name)
        {
            var config = new MapperConfiguration(r => r.CreateMap<UserDTO, RegistrationModel>()).CreateMapper();
            var users = config.Map<IEnumerable<UserDTO>, List<RegistrationModel>>(UserService.GetUsers(name));
            ViewBag.UserList = users;

            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;

            List<string> cultures = new List<string>() { "en", "ru" };
            if (!cultures.Contains(lang))
                lang = "en";

            HttpCookie cultCookie = Request.Cookies["lang"];
            if (cultCookie != null)
                cultCookie.Value = lang;
            else
            {
                cultCookie = new HttpCookie("lang");
                cultCookie.HttpOnly = false;
                cultCookie.Value = lang;
                cultCookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cultCookie);
            return Redirect(returnUrl);
        }
    }
}