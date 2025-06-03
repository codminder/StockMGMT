using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Repositories;

public class CuctomerRepository
{
    private readonly AppDbContext _context;

    public CuctomerRepository()
    {
        var connectionstring = "Host=localhost;Port=5432;database=stockdb;Username=postgres;Password=passpass";
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseNpgsql(connectionstring);
        _context = new AppDbContext(optionBuilder.Options);
    }

    public Customer CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public Customer GetById(int id)
    {
        return null;
    }
}