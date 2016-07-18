using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class UserPlaceViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "FirstName")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "Description")]
        public string Description { get; set; }
        [Required]
        public double GeoLong { get; set; }
        [Required]
        public double GeoLat { get; set; }
    }
}
