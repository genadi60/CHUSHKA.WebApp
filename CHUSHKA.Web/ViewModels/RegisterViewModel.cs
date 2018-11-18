using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Username")]
        [RegularExpression(@"(\S)+", ErrorMessage = " White Space is not allowed in Usernames")]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
