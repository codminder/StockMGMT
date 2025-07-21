using System.ComponentModel.DataAnnotations;

namespace WebApp.DataContracts.Auth
{
    public class LoginCustomerDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}