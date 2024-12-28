using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data.Auth;
using ProductCatalog.Data.Entities;
using ProductCatalog.Repo.EntityConfiguration;


namespace ProductCatalog.Repo
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-E5HQPQSL\SQLEXPRESS;Initial Catalog=ProductCatalogDB;Integrated Security=True;Trust Server Certificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            #region Seed
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id=1,
                Name="Electronics"
            },

            new Category
            {
                Id = 2,
                Name = "Clothing"
            },

            new Category
            {
                Id = 3,
                Name = "Food"
            });

            #endregion
        }

        //void SaveChanges()
        //{
        //    base.SaveChanges();
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
