using WebApp.DataContracts;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;

public class CustomerService
{
    private CustomerRepository repository;

    public CustomerService()
    {
        repository = new CustomerRepository();
    }

    public Customer Create(Customer customer)
    {
        var createCustomer = repository.CreateCustomer(customer);
        return createCustomer;
    }

    public CustomerViewModel GetById(int id)
    {
        return null;
    }
    
}