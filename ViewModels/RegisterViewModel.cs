using System.ComponentModel.DataAnnotations;

namespace beltexam4.ViewModels {
    public class RegisterViewModel {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$")]
        [MinLength(2)]
        [Display(Name = "Alias")]
        public string alias { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$")]
        [MinLength(2)]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [MinLength(8)]
        [Compare("password", ErrorMessage = "Passwords must match mother fucker!")]
        [Display(Name = "Confirm Password")]
        public string compare { get; set; }
    }
}