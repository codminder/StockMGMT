using System.ComponentModel.DataAnnotations;

namespace WebApp.DataContracts.Auth
{
    public class LoginCustomerDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}