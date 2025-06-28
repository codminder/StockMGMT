using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var jwt = _userService.GetToken(result);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt)
            });
        }

        return Unauthorized();
    }
};