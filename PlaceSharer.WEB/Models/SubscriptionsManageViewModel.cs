using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class SubscriptionsManageViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Posts Count")]
        public string PostsCount { get; set; }

        [ScaffoldColumn(false)]
        public string SubscriptionUserId { get; set; }
        [ScaffoldColumn(false)]
        public string SubscriptionUserName { get; set; } 
    }
}
