using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceSharer.DAL.Entities
{
    public class Subscription
    {
        [Key]
        [ForeignKey("SubscriptionUser")]
        public string SubscriptionUserId { get; set; }

        public string SubscriberId { get; set; }
        public virtual ApplicationUser Subscriber { get; set; }
        
        public virtual ApplicationUser SubscriptionUser { get; set; }
    }
}
