using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductCatalog.Service
{
    public interface ICategoryService
    {
        List<SelectListItem> GetAllCategories();
    }
}
