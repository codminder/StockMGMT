using WebApp.DataContracts;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;

public class CustomerService
{
    private ProductRepository repository;

    public CustomerService()
    {
        repository = new ProductRepository();
    }

    public Customer Create(Customer customer)
    {
        var createCustomer = repository.CreateCustomer(customer);
        return createCustomer;
    }

    public CustomerViewModel GetProductById(int id)
    {
        return null;
    }
    
}