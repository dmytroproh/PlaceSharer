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
using PlaceSharer.BLL.Services;

namespace PlaceSharer.WEB.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
       [HttpPost]
       public ActionResult Subscribe(string subscriptionUser)
        {
            string a = subscriptionUser;

            return RedirectToAction("UserSearch", "Home");
        }
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Manage()
        {
            return View();
        }
    }
}