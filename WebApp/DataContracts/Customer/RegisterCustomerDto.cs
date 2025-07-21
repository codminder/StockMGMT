using System.ComponentModel.DataAnnotations;

namespace WebApp.DataContracts.Auth
{
    public class RegisterCustomerDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty; // Will be hashed before saving

        [Required]
        public string Street { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        public string? AppartmentNumber { get; set; }
    }
}