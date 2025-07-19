using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer[]> GetAsync();
        Task<Customer> GetAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task UpdateAsync(Customer customer);
    }
}