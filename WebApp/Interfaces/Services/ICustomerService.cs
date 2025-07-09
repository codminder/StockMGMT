using WebApp.Models;

namespace WebApp.Interfaces.Services;

public interface ICustomerService
{
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer[]> GetAsync();
    Task<Customer> GetAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(Customer customer);
}