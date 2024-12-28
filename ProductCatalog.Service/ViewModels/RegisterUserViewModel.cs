using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Service.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
