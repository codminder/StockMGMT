using System.ComponentModel.DataAnnotations;

namespace WebApp.DataContracts;

public class CreateCustomerModel
{
    [Required]
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public required string LastName { get; set; }
    [Required]
    public required string Street { get; set; }
    [Required]
    public required string PostalCode { get; set; }
    [Required]
    public required int AppartmentNumber { get; set; }
}