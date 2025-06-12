using WebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApp.Repositories;

public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository()
    {
        var connectionstring = "Host=localhost;Port=5432;database=stockdb;Username=postgres;Password=passpass";
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionstring);
        _context = new AppDbContext(optionsBuilder.Options);
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