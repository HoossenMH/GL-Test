using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.ProductCategories;

namespace GLTest.Core.Domains.Products
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        protected Product() { }

        protected Product Create(string name)
        {
            return new Product
            {
                ProductName = name
            };
        }

        public void AddCategory(Category category)
        {
            if (ProductCategories.Any(pc => pc.CategoryId == category.CategoryId))
            {
                throw new InvalidOperationException("Category already added to this product.");
            }

            ProductCategories.Add(new ProductCategory { ProductId = this.ProductId, CategoryId = category.CategoryId });
        }
    }
}
