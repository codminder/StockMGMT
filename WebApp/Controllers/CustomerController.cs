using Microsoft.AspNetCore.Mvc;
using WebApp.DataContracts;
using WebApp.Interfaces.Services;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public CustomerViewModel[] Mapper(Customer[] model)
    {
        List<CustomerViewModel> customers = new();
        foreach (var customer in model)
        {
            var mappedModel = Mapper(customer);
            customers.Add(mappedModel);
        }

        return customers.ToArray();

    }

    [HttpGet("{id}")]
    public ActionResult<CustomerViewModel> GetCustomer(int id)
    {
        var customer = _customerService.GetCustomerById(id);
        
        if (customer != null)
        {
            return Ok(customer);
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<CustomerViewModel> Post([FromBody] CreateCustomerModel model)
    {
        var mappedModel = Mapper(model);
        var service = new CustomerService();
        var domainModel = service.Create(mappedModel);
        var viewModel = Mapper(domainModel);
        return Ok(viewModel);
    }

    [HttpPut]
    public ActionResult Update([FromBody] UpdateCustomerModel model)
    {
        var service = new CustomerService();

        var domainModel = Mapper(model);
        service.Update(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var service = new CustomerService();
        service.Delete(id);

        return Ok();
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