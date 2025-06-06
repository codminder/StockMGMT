namespace WebApp.DataContracts;

public class CustomerListViewModel
{
    public List<CustomerViewModel> Customers { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public int Appartment { get; set; }
}