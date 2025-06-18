using WebApp.Models;

namespace WebApp.Interfaces.Services;

public interface ICustomerService
{
    Customer[] GetAll();
    Customer GetCustomerById(int id);
    void Delete(int id);
    void Update(Customer customer);
}