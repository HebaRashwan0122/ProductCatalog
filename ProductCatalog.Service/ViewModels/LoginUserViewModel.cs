using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Service.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
