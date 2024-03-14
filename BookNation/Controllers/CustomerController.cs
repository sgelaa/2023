using BookNation.Controllers;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookNation.Presentation.Controllers
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
    }
}
