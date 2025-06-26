using WebApp.Models;

namespace WebApp.Interfaces.Services;

public interface IProductService
{
    Task<Product[]> GetAllAsync();
    Task<Product> GetProductByIdAsync(int id);
    Product Create(Product product);
    Task DeleteAsync(int id);
    Task UpdateAsync(Product product);
}