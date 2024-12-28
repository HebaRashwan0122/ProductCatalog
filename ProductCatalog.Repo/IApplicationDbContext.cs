using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data.Entities;

namespace ProductCatalog.Repo
{
    public interface IApplicationDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        void SaveChanges();
    }
}
