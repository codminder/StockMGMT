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
    public async Task<ActionResult<CustomerViewModel[]>> GetAllAsync()
    {
        var customers = await _customerService.GetAsync();
        var viewModel = Mapper(customers);

        return viewModel;
    }

    private CustomerViewModel[] Mapper(Customer[] model)
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
        var customer = _customerService.GetAsync(id);
        
        if (customer != null)
        {
            return Ok(customer);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CustomerViewModel>> Post([FromBody] CreateCustomerModel model)
    {
        var mappedModel = Mapper(model);

        var domainModel = await _customerService.CreateAsync(mappedModel);
        var viewModel = Mapper(domainModel);
        return Ok(viewModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateCustomerModel model)
    {
        var domainModel = Mapper(model);
        await _customerService.UpdateAsync(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _customerService.DeleteAsync(id);

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