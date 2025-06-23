using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApp.DataContracts;
using WebApp.Interfaces.Services;

namespace WebApp.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDto model)
    {
        var result = _userService.Login(model.Username, model.Password);


        if (result != null)
        {
            var jwt = GetToken(result.Email);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt)
            });
        }

        return Unauthorized();
    }

    private JwtSecurityToken GetToken(string email)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DitIsSuperSecretPlusZestienKarakters"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "StockMGMT",
            audience: "StockMGMTUI",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return token;
    }
};