using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class SubscriptionModel
    {
        [ScaffoldColumn(false)]
        public string SubscriberId { get; set; }
        
        [ScaffoldColumn(false)]
        public string SubscriptionUserId { get; set; }
        
        public string SubscriptionUserName { get; set; }

    }
}
