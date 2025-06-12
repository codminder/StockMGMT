using Microsoft.AspNetCore.Mvc;
using WebApp.DataContracts;
using WebApp.MockData;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public CustomerListViewModel Get()
    {
        return MockCustomerList.CustomerList;
    }
    
    [HttpGet("{id}")]
    public ActionResult<CustomerViewModel> GetProduct(int id)
    {
        var customer = MockCustomerList.CustomerList.Customers.FirstOrDefault(c => c.Id == id);
        if (id == 3)
        {
            return Unauthorized();
        }

        if (customer != null)
        {
            return Ok(customer);
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<CustomerViewModel> Post([FromBody] CreateCustomerModel model)
    {
        //Console.WriteLine(model);
        var mappedModel = Mapper(model);
        var service = new CustomerService();
        var domainModel = service.Create(mappedModel);
        var viewModel = Mapper(domainModel);
        return Ok(viewModel);
    }
    
    private Customer Mapper(CreateCustomerModel model)
    {
        return new Customer()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Street = model.Street,
            PostalCode = model.PostalCode,
            AppartmentNumber = model.AppartmentNumber
        };
    }

    private CustomerViewModel Mapper(Customer model)
    {
        return new CustomerViewModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Street = model.Street,
            PostalCode = model.PostalCode,
            AppartmentNumber = model.AppartmentNumber
        };
    }
}