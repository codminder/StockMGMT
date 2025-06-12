using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Repositories;

public class CustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository()
    {
        var connectionstring = "Host=localhost;Port=5432;database=stockdb;Username=postgres;Password=passpass";
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseNpgsql(connectionstring);
        _context = new AppDbContext(optionBuilder.Options);
    }

    public Customer GetById(int id)
    {
        return _context.Customers.Single(x => x.Id == id);
    }
    public Customer CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public Customer[] GetAll()
    {
        return _context.Customers.ToArray();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var customerToBeDeleted = GetById(id);
        _context.Customers.Remove(customerToBeDeleted);
        _context.SaveChanges();
    }
    /*
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
    */
}