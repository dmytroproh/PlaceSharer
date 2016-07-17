using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.WEB.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "CurrentPass")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "NewPass")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resource), Name = "ConfirmNewPass")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
