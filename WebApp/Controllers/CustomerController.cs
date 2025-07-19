using System.Threading.Tasks;
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

        return Ok(viewModel);
    }

    private Customer Mapper(UpdateCustomerModel model)
    {
        return new Customer()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Street = model.Street,
            PostalCode = model.PostalCode,
            AppartmentNumber = model.AppartmentNumber
        };
    }

     private CustomerViewModel[] Mapper(Customer[] model)
    {
        return model.Select(Mapper).ToArray();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerViewModel>> GetCustomer(int id)
    {
        var customer = await _customerService.GetAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(Mapper(customer));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerViewModel>> Post([FromBody] CreateCustomerModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var mappedModel = Mapper(model);

        var domainModel = await _customerService.CreateAsync(mappedModel);
        var viewModel = Mapper(domainModel);

        return CreatedAtAction(nameof(GetCustomer), new { id = viewModel.Id }, viewModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateCustomerModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var domainModel = Mapper(model);
        await _customerService.UpdateAsync(domainModel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var customer = await _customerService.GetAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        await _customerService.DeleteAsync(id);
        return NoContent();
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