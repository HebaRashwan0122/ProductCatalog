using ProductCatalog.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
