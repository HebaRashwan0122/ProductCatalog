using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductCatalog.Service.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<ProductListViewModel> Products { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
    }
}
