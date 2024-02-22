using BookNation.DataAccess.Entities;
using BookNation.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BookNation.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }
    }
}
