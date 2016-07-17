using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class EditUserViewModel
    {
        
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "FirstName")]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "LastName")]
        public string LastName { get; set; }
    }
}
