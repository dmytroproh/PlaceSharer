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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
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
            
            // создадим список данных
            List<PlaceDTO> placeDTO = new List<PlaceDTO>();
            placeDTO.Add(new PlaceDTO()
            {
                Id = "1",
                GeoLat = 37.610489f,
                GeoLong = 55.752308f,
              
            });
            placeDTO.Add(new PlaceDTO()
            {
                Id = "2",
                GeoLat = 38.210489f,
                GeoLong = 54.252308f,
            });
            placeDTO.Add(new PlaceDTO()
            {
                Id = "3",
                GeoLat = 36.610489f,
                GeoLong = 51.28308f,
            });

            return Json(placeDTO, JsonRequestBehavior.AllowGet);
        }
    }
}