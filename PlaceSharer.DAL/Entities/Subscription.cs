using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceSharer.DAL.Entities
{
    public class Subscription
    {
        [Key]
        public string Id { get; set; }

        public string SubscriberId { get; set; }
        public virtual ApplicationUser Subscriber { get; set; }

        //[ForeignKey("ApplicationUser")]
        public string SubscriptionUserId { get; set; }
        public virtual ApplicationUser SubscriptionUser { get; set; }
        
        public Subscription()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
