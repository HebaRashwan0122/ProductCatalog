using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Moq;
using ProductCatalog.Service;
using ProductCatalog.Web.Controllers;

namespace ProductCatalog.Test
{
    public class TestProductController
    {
        private readonly Mock<IProductService> productService;
        private readonly Mock<ICategoryService> categoryService;
        private readonly Mock<ILogger<ProductController>> logger;

        public TestProductController()
        {
            productService = new Mock<IProductService>();
            categoryService = new Mock<ICategoryService>();
            logger=new Mock<ILogger<ProductController>>();
        }

        [Fact]
        public void Test_CreateProduct_GET_ReturnsViewResult()
        {
            // Arrange
            var categorySamples = GetCategoriesList();

            categoryService.Setup(x => x.GetAllCategories())
                .Returns(GetCategoriesList());
            var controller = new ProductController(productService.Object,categoryService.Object,logger.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
           
        }

        private List<SelectListItem> GetCategoriesList()
        {
            List<SelectListItem> categories = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Electronics",
                    Value="1"
                },
                new SelectListItem
                {
                    Text="Clothing",
                    Value="2"
                },
                new SelectListItem
                {
                    Text="Food",
                    Value="3"
                }

            };
            return categories;
        }

    }
}
