using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNation.Logic.Interfaces
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(CustomerDto customerDto)
        {
            return await _customerRepository.AddCustomerAsync(customerDto);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _customerRepository.GetCustomerAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        public async Task<Customer> RemoveCustomerAsync(int id)
        {
            return await _customerRepository.RemoveCustomerAsync(id);
        }
    }
}
