using System.ComponentModel.DataAnnotations;
namespace beltexam4.ViewModels {
    public class LoginViewModel {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string password { get; set; }

    }
}