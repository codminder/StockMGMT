using System.ComponentModel.DataAnnotations;

namespace WebApp.DataContracts.Auth
{
    public class RegisterCustomerDto
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string PostalCode { get; set; }
        [Required]
        public required string AppartmentNumber { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

    }
}