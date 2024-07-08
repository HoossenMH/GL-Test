using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;

namespace GLTest.Core.Domains.ProductCategories
{
    public class ProductCategory
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
