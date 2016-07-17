using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
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
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private ISubscriptionService SubscriptionService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ISubscriptionService>();
            }
        }

       [HttpPost]
       public async Task<ActionResult> Subscription(string subscriptionUser,string unSubscriptionUser)
        {
            if (subscriptionUser != null && unSubscriptionUser == null)
            {
                SubscriptionDTO subscriptionDto = new SubscriptionDTO
                {
                    SubscriberId = User.Identity.GetUserId(),
                    SubscriptionUserId = await SubscriptionService.GetSubscriptionIdByName(subscriptionUser)
                };

                OperationDetails operationDetails = await SubscriptionService.CreateAsync(subscriptionDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Friend");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);

                return RedirectToAction("Index", "Home");
            } else if(subscriptionUser == null && unSubscriptionUser != null)
            {
                SubscriptionDTO subscriptionDto = new SubscriptionDTO
                {
                    SubscriberId = User.Identity.GetUserId(),
                    SubscriptionUserId = await SubscriptionService.GetSubscriptionIdByName(unSubscriptionUser)
                };

                OperationDetails operationDetails = await SubscriptionService.RemoveAsync(subscriptionDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Friend");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

      
        public ActionResult Index()
        {
            return View();
        }
    }
}