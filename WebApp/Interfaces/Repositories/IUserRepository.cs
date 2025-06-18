using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface IUserRepository
{
    User? GetByEmail(string email);
    User? GetById(int id);
    User CreateUser(User user);
    void UpdateUser(User user);
    void DeleteById(int id);
}