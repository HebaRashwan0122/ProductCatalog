using ProductCatalog.Data.Entities;
using System.Collections.Generic;

namespace ProductCatalog.Repo
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        List<Product> GetByCategoryId(int categoryId);
        void Insert(Product product);
        void Update(int id, Product entity);
        void Delete(int id);
    }
}
