using GLTest.Core.Common;
using GLTest.Core.DataModels;
using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.ProductCategories;
using GLTest.Core.Domains.Products;
using Microsoft.EntityFrameworkCore;

namespace GLTest.Core.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly Configuration _config;

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, Configuration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.ConnectionStrings.AppDbContext);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfigurations());
            builder.ApplyConfiguration(new ProductConfigurations());
            builder.ApplyConfiguration(new ProductCategoryConfigurations());
        }
    }
}
