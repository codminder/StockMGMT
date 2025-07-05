using WebApp.Models;
using WebApp.Interfaces.Repositories;
using WebApp.Interfaces.Services;

namespace WebApp.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUserService _userService;
    public ProductService(IProductRepository productRepository, IUserService userService)
    {
        _productRepository = productRepository;
        _userService = userService;
    }

    public async Task<Product[]> GetAsync()
    {
        return await _productRepository.GetAsync();
    }

    public async Task<Product> GetAsync(int id)
    {
        return await _productRepository.GetAsync(id);
    }
    public async Task<Product> CreateAsync(Product product)
    {
        var userIdFromToken = _userService.GetCurrentUser().Id;
        product.UserId = userIdFromToken;
        var createdProduct = await _productRepository.CreateAsync(product);
        return createdProduct;
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }

public async Task UpdateAsync(Product product)
    {
        var dbModel = await _productRepository.GetAsync(product.Id);

        dbModel.Name = product.Name;
        dbModel.Description = product.Description;
        dbModel.Price = product.Price;
        dbModel.DiscountPercentage = product.DiscountPercentage;
        dbModel.Stock = product.Stock;

        await _productRepository.UpdateAsync(dbModel);
    }
}

