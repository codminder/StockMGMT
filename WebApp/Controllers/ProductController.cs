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

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ProductViewModel[]>> GetAllAsync()
    {
        var products = await _productService.GetAsync();
        var viewModel = Mapper(products);

        return viewModel;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
    {
        var product = await _productService.GetAsync(id);

        if (product != null)
        {
            return Ok(product);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> PostAsync([FromBody] CreateProductModel model)
    {
        var domainModel = Mapper(model);
        var createdModel = await _productService.CreateAsync(domainModel);
        var viewModel = Mapper(createdModel);
        return Ok(viewModel);

    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateProductModel model) // heeft niet!
    {
        var domainModel = Mapper(model);
        await _productService.UpdateAsync(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _productService.DeleteAsync(id);
        return Ok();
    }

    private static ProductViewModel[] Mapper(Product[] model)
    {
        List<ProductViewModel> products = [];
        foreach (var product in model)
        {
            var mappedObject = Mapper(product);
            products.Add(mappedObject);
        }

        return [.. products];
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

    private static Product Mapper(UpdateProductModel model)
    {
        return new Product()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Stock = model.Stock,
            DiscountPercentage = model.DiscountPercentage
        };
    }
}
