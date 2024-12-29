using Microsoft.Extensions.Logging;
using ProductCatalog.Data.Entities;
using ProductCatalog.Repo;
using ProductCatalog.Service.ViewModels;

namespace ProductCatalog.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public List<ProductListViewModel> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAll().Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreationDate = p.CreationDate,
                    DurationInHours = p.DurationInHours,
                    Img = p.Img,
                    Price = p.Price,
                    StartDate = p.StartDate

                }).ToList();
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                return new List<ProductListViewModel>();
            }
        }

        public ProductEditViewModel GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                var model = new ProductEditViewModel();
                if (product != null)
                {
                    model = new ProductEditViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        DurationInHours = product.DurationInHours,
                        Price = product.Price,
                        StartDate = product.StartDate
                    };
                }
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                return null;
            }
        }

        public ProductDetailsViewModel GetProductDetails(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product != null)
                {
                    var model = new ProductDetailsViewModel
                    {
                        Id = id,
                        Name = product.Name,
                        Price = product.Price,
                        Img = product.Img
                    };
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                return null;
            }
        }

        public List<ProductListViewModel> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                var products = _productRepository.GetByCategoryId(categoryId).Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreationDate = p.CreationDate,
                    DurationInHours = p.DurationInHours,
                    Img = p.Img,
                    Price = p.Price,
                    StartDate = p.StartDate

                }).ToList();
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                return null;
            }
        }

        public void InsertProduct(ProductCreateViewModel productVM)
        {
            try
            {
                var product = new Product
                {
                    Name = productVM.Name,
                    StartDate = productVM.StartDate,
                    DurationInHours = productVM.DurationInHours,
                    Price = productVM.Price,
                    CategoryId = productVM.SelectedCategory,
                    CreationDate = DateTime.Now,
                    CreatedBy = productVM.CreatedBy,
                    Img = productVM.Img
                };
                _productRepository.Insert(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
            }
        }

        public void UpdateProduct(int id,ProductEditViewModel model)
        {
            try
            {
                var product = new Product
                {
                    Name = model.Name,
                    StartDate = model.StartDate,
                    DurationInHours = model.DurationInHours,
                    Price = model.Price
                };
                _productRepository.Update(id, product);
            }
            catch (Exception ex)
            {
               _logger.LogError($"Error {ex.Message}");
            }
        }


        public void DeleteProduct(int id)
        {
            try
            {
                _productRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
            }
        }
    }
}
