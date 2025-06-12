using WebApp.DataContracts;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;
public class ProductService
{
    private readonly ProductRepository repository;

    public ProductService()
    {
        repository = new ProductRepository();
    }

    public Product[] GetAll()
    {
        return repository.GetAll();
    }

    public Product GetProductById(int id)
    {
        return repository.GetById(id);
    }
    public Product Create(Product product)
    {
        var createdProduct = repository.CreateProduct(product);
        return createdProduct;
    }

    public void Delete(int id)
    {
        repository.DeleteById(id);
    }

    public void Update(Product product)
    {
        var dbModel = repository.GetById(product.Id);

        dbModel.Name = product.Name;
        dbModel.Description = product.Description;
        dbModel.Price = product.Price;
        dbModel.DiscountPercentage = product.DiscountPercentage;
        dbModel.Stock = product.Stock;

        repository.UpdateProduct(dbModel);
    }
}
