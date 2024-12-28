using ProductCatalog.Data.Entities;
using ProductCatalog.Repo;
using ProductCatalog.Service.ViewModels;

namespace ProductCatalog.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductListViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll().Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate= p.CreationDate,
                DurationInHours= p.DurationInHours,
                Img= p.Img,
                Price= p.Price,
                StartDate= p.StartDate

            }).ToList();
            return products;
        }

        public ProductEditViewModel GetProductById(int id)
        {
            var product =_productRepository.GetById(id);
            var model = new ProductEditViewModel();
            if (product!=null)
            {
                model = new ProductEditViewModel
                {
                    Id= product.Id,
                    Name= product.Name,
                    DurationInHours= product.DurationInHours,
                    Price= product.Price,
                    StartDate= product.StartDate
                };
            }
            return model;
        }

        public ProductDetailsViewModel GetProductDetails(int id)
        {
            var product=_productRepository.GetById(id);
            if (product!=null)
            {
                var model = new ProductDetailsViewModel
                {
                    Id=id,
                    Name = product.Name,
                    Price= product.Price,
                    Img = product.Img
                };
                return model;
            }
            return null;
        }

        public List<ProductListViewModel> GetProductsByCategoryId(int categoryId)
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

        public void InsertProduct(ProductCreateViewModel productVM)
        {
            var product = new Product
            {
                Name= productVM.Name,
                StartDate=productVM.StartDate,
                DurationInHours=productVM.DurationInHours,
                Price=productVM.Price,
                CategoryId=productVM.SelectedCategory,
                CreationDate=DateTime.Now,
                CreatedBy=productVM.CreatedBy,
                Img =productVM.Img
            };
            _productRepository.Insert(product);
        }

        public void UpdateProduct(int id,ProductEditViewModel model)
        {
            var product = new Product
            {
                Name= model.Name,
                StartDate= model.StartDate,
                DurationInHours=model.DurationInHours,
                Price=model.Price
            };
            _productRepository.Update(id, product);
        }


        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

    }
}
