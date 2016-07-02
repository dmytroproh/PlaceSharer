using Microsoft.AspNet.Identity.EntityFramework;

namespace PlaceSharer.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
