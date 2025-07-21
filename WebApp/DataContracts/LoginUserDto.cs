using System.ComponentModel.DataAnnotations;

namespace WebApp.DataContracts;

public class LoginDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
    public required string Email { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
    public required string Password { get; set; }
}