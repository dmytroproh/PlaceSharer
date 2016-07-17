using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
