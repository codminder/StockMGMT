using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using WebApp.Interfaces.Repositories;

namespace WebApp.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository()
    {
        var connectionstring = "Host=localhost;Port=5432;database=stockdb;Username=postgres;Password=passpass";
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseNpgsql(connectionstring);
        _context = new AppDbContext(optionBuilder.Options);
    }

    public async Task<Customer> GetAsync(int id)
    {
        return await _context.Customers.SingleAsync(x => x.Id == id);
    }

    public async Task<Customer[]> GetAsync()
    {
        return await _context.Customers.ToArrayAsync();
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customerToBeDeleted = await GetAsync(id);
        _context.Customers.Remove(customerToBeDeleted);
        await _context.SaveChangesAsync();
    }
}