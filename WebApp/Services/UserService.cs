using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WebApp.Interfaces.Repositories;
using WebApp.Interfaces.Services;
using WebApp.Models;

namespace WebApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository, IHttpContextAccessor IHttpContextAccessor)
    {
        _repository = repository;
    }

    public User? Login(string email, string password)
    {
        var user = _repository.GetByEmail(email);

        if (user != null)
        {
            if (user.Password == password)
            {
                user.LastLoginDate = DateTime.UtcNow;
                _repository.UpdateUser(user);

                return user;
            }
        }
        return null;
    }

    public User GetCurrentUser()
    {
        var contextUser = _httpContextAccessor.HttpContext?.User;

        var userClaim = contextUser?.FindFirst(ClaimTypes.NameIdentifier);
    }
}