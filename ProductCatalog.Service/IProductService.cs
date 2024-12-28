using ProductCatalog.Service.ViewModels;

namespace ProductCatalog.Service
{
    public interface IProductService
    {
        List<ProductListViewModel> GetAllProducts();
        ProductEditViewModel GetProductById(int id);
        ProductDetailsViewModel GetProductDetails(int id);
        List<ProductListViewModel> GetProductsByCategoryId(int categoryId);
        void InsertProduct(ProductCreateViewModel product);
        void UpdateProduct(int id, ProductEditViewModel model);
        void DeleteProduct(int id);
    }
}
