using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Service.ViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [MaxLength(50, ErrorMessage = "Product Name must not exceed 50 characters")]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public int? DurationInHours { get; set; }
        public double Price { get; set; }

    }
}
