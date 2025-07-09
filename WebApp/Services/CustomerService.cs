using WebApp.DataContracts;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Interfaces.Services;
using WebApp.Interfaces.Repositories;

namespace WebApp.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer[]> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<Customer> GetAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        var createdCustomer = await _repository.CreateAsync(customer);
        return createdCustomer;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Customer customer)
    {
        var dbModel = await _repository.GetAsync(customer.Id);

        dbModel.FirstName = customer.FirstName;
        dbModel.LastName = customer.LastName;
        dbModel.AppartmentNumber = customer.AppartmentNumber;
        dbModel.PostalCode = customer.PostalCode;
        dbModel.Street = customer.Street;

        await _repository.UpdateAsync(dbModel);
    }
    
    
}