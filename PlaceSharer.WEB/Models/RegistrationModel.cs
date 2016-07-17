using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect Email")]
        [Display(Name = "e-mail: ")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "ConfirmPass")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "FirstName")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "LastName")]
        public string LastName { get; set; }
    }
}
