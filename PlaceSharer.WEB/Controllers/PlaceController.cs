using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaceSharer.WEB.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}