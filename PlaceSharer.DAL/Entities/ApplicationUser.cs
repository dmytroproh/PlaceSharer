using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace PlaceSharer.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Subscription SubscriptionUser { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }
        
        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public ApplicationUser()
        {
            Places = new List<Place>();
            Subscriptions = new List<Subscription>();
        }
    }
}
