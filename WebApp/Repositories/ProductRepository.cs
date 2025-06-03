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
    
    public Product CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }
    public Product GetById(int id)
    {
        return null;
    }
}