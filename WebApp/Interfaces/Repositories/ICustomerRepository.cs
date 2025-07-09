using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer> GetAsync(int id);
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer[]> GetAsync();
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}
