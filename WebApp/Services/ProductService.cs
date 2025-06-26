using WebApp.Models;
using WebApp.Interfaces.Repositories;
using WebApp.Interfaces.Services;

namespace WebApp.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product[]> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public Product Create(Product product)
    {
        var createdProduct = _repository.CreateProduct(product);
        return createdProduct;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }

    public async Task UpdateAsync(Product product)
    {
        var dbModel = await _repository.GetByIdAsync(product.Id);

        dbModel.Name = product.Name;
        dbModel.Description = product.Description;
        dbModel.Price = product.Price;
        dbModel.DiscountPercentage = product.DiscountPercentage;
        dbModel.Stock = product.Stock;

        _repository.UpdateProduct(dbModel);
    }
}
