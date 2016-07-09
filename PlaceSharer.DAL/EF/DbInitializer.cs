using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PlaceSharer.DAL.Identity;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            //var userRole = new IdentityRole { Name = "user" };

            var role = new ApplicationRole { Name = "user" };
            roleManager.Create(role);
            
            base.Seed(context);
        }
    }
}
