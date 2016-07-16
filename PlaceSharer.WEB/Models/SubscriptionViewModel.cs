using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class SubscriptionViewModel
    {
        [ScaffoldColumn(false)]
        public string SubscriberId { get; set; }

        [ScaffoldColumn(false)]
        public string ScbscriberUserName { get; set; }

        [ScaffoldColumn(false)]
        public string ScbscribeUserId { get; set; }
        [ScaffoldColumn(false)]
        public string ScbscribeUserName { get; set; }
    }
}
