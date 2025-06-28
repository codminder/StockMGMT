using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product[]> GetAsync();
    Task<Product> GetAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}



