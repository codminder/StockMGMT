using WebApp.DataContracts;

namespace WebApp.MockData;

public static class MockCustomerList
{
    public static CustomerListViewModel CustomerList = new CustomerListViewModel()
    {
        Customers =
        [
            new CustomerViewModel()
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Ipkis",
                Street = "1st Avenue",
                PostalCode = "2838ISM",
                AppartmentNumber = 34
            },
            new CustomerViewModel()
            {
                Id = 2,
                FirstName = "Lary",
                LastName = "Wheels",
                Street = "2nd Avenue",
                PostalCode = "9338ISM",
                AppartmentNumber = 23
            },
            new CustomerViewModel()
            {
                Id = 3,
                FirstName = "Bary",
                LastName = "Klark",
                Street = "5th Avenue",
                PostalCode = "2869GSM",
                AppartmentNumber = 43
            }
        ]
    };
}