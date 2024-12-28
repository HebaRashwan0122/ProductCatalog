using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog.Service.ViewModels;

namespace ProductCatalog.Service
{
    public interface ICategoryService
    {
        List<SelectListItem> GetAllCategories();
    }
}
