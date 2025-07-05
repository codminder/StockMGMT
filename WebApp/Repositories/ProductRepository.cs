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

    public async Task<Product> GetAsync(int id)
    {
        return await _context.Products.SingleAsync(x => x.Id == id);
    }
    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product[]> GetAsync()
    {
        return await _context.Products.ToArrayAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var productToBeDeleted = await GetAsync(id);
        _context.Products.Remove(productToBeDeleted);
        await _context.SaveChangesAsync();
    }
    
}