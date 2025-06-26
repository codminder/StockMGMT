using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Product CreateProduct(Product product);
    Task<Product[]> GetAllAsync();
    void UpdateProduct(Product product);
    Task DeleteByIdAsync(int id);

}



