using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Presenter.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerId(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            return Ok(customer);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Customer>> Add(CustomerDto customerDto)
        {
            return Created("new customer created.", await _customerService.AddCustomerAsync(customerDto));
        }

        [HttpDelete("Remove/{removeId}")]
        public async Task<ActionResult<Customer>> RemoveId(int removeId)
        {
            return Ok(await _customerService.RemoveCustomerAsync(removeId));
        }
    }
}
