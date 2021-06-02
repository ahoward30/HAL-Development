using System.ComponentModel.DataAnnotations;

namespace ITMatching.Models.InputModels
{
    public class ClientRegisterInputModel
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z]*", ErrorMessage = "Invalid name, names cannot contain symbols or numbers.")]
        [StringLength(100, ErrorMessage = "Please enter your First name", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]*", ErrorMessage = "Invalid name, names cannot contain symbols or numbers.")]
        [StringLength(100, ErrorMessage = "Please enter your Last name", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Not a valid phone number")]
        [StringLength(100, ErrorMessage = "Please enter your primary phone number", MinimumLength = 6)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string captchaInput { get; set; }
    }
}
