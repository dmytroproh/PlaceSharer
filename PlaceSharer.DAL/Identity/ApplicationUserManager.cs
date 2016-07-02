using Microsoft.AspNet.Identity;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}
