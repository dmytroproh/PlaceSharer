using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace PlaceSharer.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
        
        public ICollection<Place> Places { get; set; }
    }
}
