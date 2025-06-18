using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataContracts;
using WebApp.Interfaces.Services;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService){
        _productService = productService;
    }

    [HttpGet]
    public ProductViewModel[] GetAll()
    {
        var products = _productService.GetAll();
        var viewModel = Mapper(products);

        return viewModel;
    }

    [HttpGet("{id}")]
    public ActionResult<ProductViewModel> GetProduct(int id)
    {
        var service = _productService;
        var product = service.GetProductById(id);

        if (product != null)
        {
            return Ok(product);
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<ProductViewModel> Post([FromBody] CreateProductModel model)
    {
        var service = _productService;

        var domainModel = Mapper(model);
        var createdModel = service.Create(domainModel);
        var viewModel = Mapper(createdModel);
        return Ok(viewModel);

    }

    [HttpPut]
    public ActionResult Update([FromBody] UpdateProductModel model) // heeft niet!
    {
        var service = _productService;
        var domainModel = Mapper(model);
        service.Update(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var service = _productService;

        service.Delete(id);
        return Ok();
    }

    private static ProductViewModel[] Mapper(Product[] model)
    {
        List<ProductViewModel> products = new();
        foreach (var product in model)
        {
            var mappedObject = Mapper(product);
            products.Add(mappedObject);
        }

        return products.ToArray();
    }

    private static ProductViewModel Mapper(Product model)
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


    private static Product Mapper(CreateProductModel model)
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
