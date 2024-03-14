using BookNation.DataAccess.Entities;
using BookNation.Logic.Interfaces;

namespace BookNation.Logic.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }
    }
}
