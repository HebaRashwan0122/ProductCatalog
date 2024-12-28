using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog.Repo;
using ProductCatalog.Service.ViewModels;

namespace ProductCatalog.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<SelectListItem> GetAllCategories()
        {
            return _categoryRepository.GetAll()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() })
                .ToList();
        }
    }
}
