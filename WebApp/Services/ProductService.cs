using WebApp.DataContracts;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;
public class ProductService
{
    private ProductRepository repository;

    public ProductService()
    {
        repository = new ProductRepository();
    }

    public Product Create(Product product)
    {
        var createdProduct = repository.CreateProduct(product);
        return createdProduct;
    }
    
    public ProductViewModel GetProductById(int id)
    {
        return null;
    }
}
