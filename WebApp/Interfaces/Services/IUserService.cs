using System.IdentityModel.Tokens.Jwt;
using WebApp.Models;

namespace WebApp.Interfaces.Services;

public interface IUserService
{
    User? Login(string email, string password);
    User GetCurrentUser();
    JwtSecurityToken GetToken(User user);

}