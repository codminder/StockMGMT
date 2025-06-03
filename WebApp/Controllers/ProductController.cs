using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp.DataContracts;
using WebApp.MockData;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ProductListViewModel Get()
        {
            return MockProductList.ProductList;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> GetProduct(int id)
        {
            var product = MockProductList.ProductList.Products.FirstOrDefault(p => p.Id == id);

            if (id == 3)
            {
                return Unauthorized();
            }
            
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ProductViewModel> Post([FromBody] CreateProductModel model)
        {
            Console.WriteLine(model);
            var service = new ProductService();
            
            var domainModel = Mapper(model);
            var createdModel = service.Create(domainModel);
            var viewModel = Mapper(createdModel);
            return Ok(viewModel);
            
        }

        private ProductViewModel Mapper(Product model)
        {
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                DiscountPercentage = model.DiscountPercentage
            };
        }
        
        private Product Mapper(CreateProductModel model)
        {
            return new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                DiscountPercentage = model.DiscountPercentage
            };
        }
    }
}
