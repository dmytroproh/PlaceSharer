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
        public ActionResult Index()
        {
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