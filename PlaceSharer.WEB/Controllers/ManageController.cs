using System.Collections.Generic;
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
    public class ManageController : Controller
    {
        
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
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

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                View(model);
            }

            ChangePasswordDTO cpDto = new ChangePasswordDTO
            {
                UserId = User.Identity.GetUserId(),
                OldPassword = model.OldPassword,
                NewPassword = model.NewPassword,
                Email = User.Identity.GetUserName()
            };

            var result = await UserService.ChangePasswordAsync(cpDto);
            if(result.Succedeed)
            {
                UserDTO userDto = new UserDTO { Email = cpDto.Email, Password = model.NewPassword };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);

                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }


    }
}