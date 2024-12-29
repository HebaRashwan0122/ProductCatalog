using ProductCatalog.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetByCategoryId(int categoryId) 
        {
            return _context.Products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id,Product entity)
        {
            var product = _context.Products.Find(id);
            if (product != null) 
            { 
                product.Name = entity.Name;
                product.StartDate = entity.StartDate;
                product.DurationInHours = entity.DurationInHours;
                product.Price= entity.Price;
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
