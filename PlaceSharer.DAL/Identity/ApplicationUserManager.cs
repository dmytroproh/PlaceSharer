using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PlaceSharer.DAL.EF;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.Services;

namespace PlaceSharer.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireLowercase = false,
                RequireUppercase = false,
                RequireNonLetterOrDigit = false,
                RequireDigit = false
            };

            EmailService = new EmailService();

            //var dataProtectionProvider = new DataProtectorTokenProvider<ApplicationUser>()
        }
    }
}
