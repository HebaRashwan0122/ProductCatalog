using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Service;
using ProductCatalog.Service.ViewModels;
using System.Security.Claims;

namespace ProductCatalog.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ICategoryService categoryService, 
            ILogger<ProductController> logger
            )
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        public IActionResult Index(string searchCategory)
        {
            var model = new ProductIndexViewModel();
            model.CategoriesList = _categoryService.GetAllCategories();
                  
            if (!string.IsNullOrEmpty(searchCategory))
            {
                model.Products = _productService.GetProductsByCategoryId(Convert.ToInt32(searchCategory));
            }
            else
            {
                model.Products= _productService.GetAllProducts();
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ProductCreateViewModel model = new ProductCreateViewModel
            {
                CategoriesList = _categoryService.GetAllCategories()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateViewModel model,IFormFile? file)
        {
            if (file!=null)
            {
                if (file.Length>0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);

                        var fileExtensions = new[] { ".jpg", ".jpeg", ".png"};
                        string filePath = Path.GetExtension(file.FileName);

                        if (ms.Length<1048576 && fileExtensions.Contains(filePath) )
                        {
                            var fileBytes = ms.ToArray();
                            model.Img = fileBytes;
                        }
                        else
                        {
                            ModelState.AddModelError("","Error in uploading product image");
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                 model.CreatedBy= HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _productService.InsertProduct(model);
                return RedirectToAction("Index");
            }
            model.CategoriesList = _categoryService.GetAllCategories();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _productService.GetProductDetails(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model=_productService.GetProductById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(id, model);
                 var currentUser = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _logger.LogInformation($"update to product by {currentUser} at {DateTime.Now}");
                
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var model = _productService.GetProductDetails(id.Value);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
