
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using WebApp.Interfaces.Repositories;
using WebApp.Interfaces.Services;
using WebApp.Models;

namespace WebApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserService(IUserRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    public User? Login(string email, string password)
    {
        var user = _userRepository.Get(email);

        if (user != null)
        {
            if (user.Password == password)
            {
                user.LastLoginDate = DateTime.UtcNow;
                _userRepository.Update(user);

                return user;
            }
        }
        return null;
    }

    public User GetCurrentUser()
    {
        var contextUser = _httpContextAccessor.HttpContext?.User;
        var userIdClaim = contextUser?.FindFirst("id");

        if (userIdClaim == null)
        {
            throw new UnauthorizedAccessException("User id not found in token.");
        }

        int userId = int.Parse(userIdClaim.Value);

        var userResult = _userRepository.Get(userId);

        if (userResult == null)
        {
            throw new NullReferenceException($"user with id ${userId} not found in the database.");
        }
        return userResult;
    }

    public JwtSecurityToken GetToken(User user)
    {
        var claims = new[]
        {
            new Claim("email", user.Email),
            new Claim("id", user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DitIsSuperSecretPlusZestienKarakters"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "StockManagement",
            audience: "StockManagementUI",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return token;
    }
}