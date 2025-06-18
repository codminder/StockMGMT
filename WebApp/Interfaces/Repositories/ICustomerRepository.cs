using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface ICustomerRepository
{
    Customer GetById(int id);
    Customer CreateCustomer(Customer customer);
    Customer[] GetAll();
    void UpdateCustomer(Customer customer);
    void DeleteById(int id);
}
