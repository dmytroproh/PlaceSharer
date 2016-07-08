using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaceSharer.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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