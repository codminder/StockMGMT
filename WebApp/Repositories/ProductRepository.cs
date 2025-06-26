using WebApp.Interfaces.Repositories;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApp.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.SingleAsync(x => x.Id == id);
    }
    public Product CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public async Task<Product[]> GetAllAsync()
    {
        return await _context.Products.ToArrayAsync();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var productToBeDeleted = await GetByIdAsync(id);
        _context.Products.Remove(productToBeDeleted);
        _context.SaveChanges();
    }
    
}