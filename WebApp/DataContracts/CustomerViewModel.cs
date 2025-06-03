namespace WebApp.DataContracts;

public class CustomerViewModel
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Street { get; set; }
    public required string PostalCode { get; set; }
    public required int AppartmentNumber { get; set; }
}