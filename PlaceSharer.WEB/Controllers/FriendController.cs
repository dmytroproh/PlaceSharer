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

        private IPlaceService PlaceService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<IPlaceService>();
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
            var configSubsc = new MapperConfiguration(r => r.CreateMap<SubscriptionDTO, SubscriptionModel>()).CreateMapper();

            var subscriptions = configSubsc.Map<IEnumerable<SubscriptionDTO>, List<SubscriptionModel>>(SubscriptionService.GetSubscriptions(User.Identity.GetUserId()));
            
            SelectList subscriptionsSL = new SelectList(subscriptions, "SubscriptionUserName", "SubscriptionUserName");
            if(ViewBag.Subscriptions == null)
                ViewBag.Subscriptions = subscriptionsSL;
            return View();
        }

        string userId = "";
        [HttpPost]
        public async Task <ActionResult> Index(string Subscriptions)
        {
            userId = await UserService.GetUserIdByName(Subscriptions);

            return View();
        }

        public JsonResult GetData()
        {
            var config = new MapperConfiguration(r => r.CreateMap<PlaceDTO, UserPlaceViewModel>()).CreateMapper();
            var places = config.Map<IEnumerable<PlaceDTO>, List<UserPlaceViewModel>>(PlaceService.GetPlacesByUserId(userId));

            return Json(places, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SubscriptionsManagement()
        {
            var configSubsc = new MapperConfiguration(r => r.CreateMap<SubscriptionsManageDTO, SubscriptionsManageViewModel>()).CreateMapper();

            var subscriptions = configSubsc.Map<IEnumerable<SubscriptionsManageDTO>, List<SubscriptionsManageViewModel>>(SubscriptionService.GetSubscriptionsWithUserInfo(User.Identity.GetUserId()));
            
            return View(subscriptions);
        }

        
        [HttpPost]
        public async Task<ActionResult> SubscriptionsManagement(string subscriptionUser, string unSubscriptionUser)
        {
            await Subscription(subscriptionUser, unSubscriptionUser);

            return View();
        }
    }
}