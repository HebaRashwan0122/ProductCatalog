using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Service.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage ="Product Name is required")]
        [MaxLength(50,ErrorMessage ="Product Name must not exceed 50 characters")]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }
        public int? DurationInHours { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        public double Price { get; set; }

        public byte[] Img { get; set; }

        public string CreatedBy { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        public int SelectedCategory { get; set; }
    }
}
