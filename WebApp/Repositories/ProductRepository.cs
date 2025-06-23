using WebApp.Interfaces.Repositories;
using WebApp.Models;
namespace WebApp.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public Product GetById(int id)
    {
        return _context.Products.Single(x => x.Id == id);
    }
    public Product CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product[] GetAll()
    {
        return _context.Products.ToArray();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var productToBeDeleted = GetById(id);
        _context.Products.Remove(productToBeDeleted);
        _context.SaveChanges();
    }
    
}