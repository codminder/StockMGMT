using WebApp.Interfaces.Repositories;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace WebApp.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetAsync(int id)
    {
        return await _context.Products.SingleAsync(x => x.Id == id);
    }
    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChanges();
        return product;
    }

    public async Task<Product[]> GetAsync()
    {
        return await _context.Products.ToArrayAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChanges();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var productToBeDeleted = await GetAsync(id);
        _context.Products.Remove(productToBeDeleted);
        _context.SaveChanges();
    }
    
}