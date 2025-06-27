using WebApp.Models;

namespace WebApp.Interfaces.Repositories;

public interface IUserRepository
{
    User? Get(string email);
    User? Get(int id);
    User Create(User user);
    void Update(User user);
    void Delete(int id);
}