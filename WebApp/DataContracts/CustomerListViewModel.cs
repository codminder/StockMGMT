namespace WebApp.DataContracts;

public class CustomerListViewModel
{
    public required List<CustomerViewModel> Customers { get; set; }
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Street { get; set; }
    public required string PostalCode { get; set; }
    public required int Appartment { get; set; }
}