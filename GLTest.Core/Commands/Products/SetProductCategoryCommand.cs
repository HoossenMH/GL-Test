using GLTest.Core.Common;
using GLTest.Core.Repositories.Categories;
using GLTest.Core.Repositories.Products;

namespace GLTest.Core.Commands.Products
{
    public class SetProductCategoryCommand : ISetProductCategoryCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetProductCategoryCommand(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<bool>> ExecuteAsync(Guid productId, Guid categoryId)
        {
            var product = await _productRepository.FirstOrDefaultAsync(a => a.ProductId == productId);
            if (product == null)
                return new CommandResult<bool>("Set_Product_Category_Product_NotFound", "Product not found. ");

            var category = await _categoryRepository.FirstOrDefaultAsync(a => a.CategoryId == categoryId);
            if (category == null)
                return new CommandResult<bool>("Set_Product_Category_Category_NotFound", "Category not found. ");

            try
            {
                product.AddCategory(category);
                await _unitOfWork.CommitAsync();
            }
            catch (InvalidOperationException ex)
            {
                return new CommandResult<bool>("Set_Product_Category_Duplicate", ex.Message);
            }

            return new CommandResult<bool>(true);
        }
    }
}
