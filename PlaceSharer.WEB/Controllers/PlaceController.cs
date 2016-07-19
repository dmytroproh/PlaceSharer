using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;
using PlaceSharer.BLL.Interfaces;
using PlaceSharer.WEB.Models;
using AutoMapper;

namespace PlaceSharer.WEB.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IPlaceService PlaceService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<IPlaceService>();
            }
        }
        
        public ActionResult Index()
        {
            var config = new MapperConfiguration(r => r.CreateMap<PlaceDTO, UserPlaceViewModel>()).CreateMapper();
            var places = config.Map<IEnumerable<PlaceDTO>, List<UserPlaceViewModel>>(PlaceService.GetPlacesByUserId(User.Identity.GetUserId()));
            ViewBag.Places = places;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserPlaceViewModel model)
        {
            if(ModelState.IsValid)
            {
                PlaceDTO place = new PlaceDTO
                {
                    Name = model.Name,
                    Description = model.Description,
                    GeoLat = model.GeoLat,
                    GeoLong = model.GeoLong,
                    UserId = User.Identity.GetUserId()
                };
            OperationDetails operationDetails = await PlaceService.CreateAsync(place);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Place");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View();
        }

        public JsonResult GetData()
        {
            var config = new MapperConfiguration(r => r.CreateMap<PlaceDTO, UserPlaceViewModel>()).CreateMapper();
            var places = config.Map<IEnumerable<PlaceDTO>, List<UserPlaceViewModel>>(PlaceService.GetPlacesByUserId(User.Identity.GetUserId()));

            return Json(places, JsonRequestBehavior.AllowGet);
        }
    }
}