using WebApp.Models;

namespace WebApp.Interfaces.Services;

public interface IUserService
{
    User? Login(string email, string password);
}