using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface IProductRepository
{
    Product GetById(int id);
    Product CreateProduct(Product product);
    Product[] GetAll();
    void UpdateProduct(Product product);
    void DeleteById(int id);

}



