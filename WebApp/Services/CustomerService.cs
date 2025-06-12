using WebApp.DataContracts;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services;

public class CustomerService
{
    private readonly CustomerRepository repository;

    public CustomerService()
    {
        repository = new CustomerRepository();
    }

    public Customer[] GetAll()
    {
        return repository.GetAll();
    }

    public Customer GetCustomerById(int id)
    {
        return repository.GetById(id);
    }

    public Customer Create(Customer customer)
    {
        var createdCustomer = repository.CreateCustomer(customer);
        return createdCustomer;
    }

    public void Delete(int id)
    {
        repository.DeleteById(id);
    }

    public void Update(Customer customer)
    {
        var dbModel = repository.GetById(customer.Id);

        dbModel.FirstName = customer.FirstName;
        dbModel.LastName = customer.LastName;
        dbModel.AppartmentNumber = customer.AppartmentNumber;
        dbModel.PostalCode = customer.PostalCode;
        dbModel.Street = customer.Street;
        repository.UpdateCustomer(dbModel);
    }
    
    
    /*
    public CustomerViewModel GetById(int id)
    {
        return null;
    }
    */
    
}