using ProductCatalog.Data.Entities;
using System.Collections.Generic;

namespace ProductCatalog.Repo
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
