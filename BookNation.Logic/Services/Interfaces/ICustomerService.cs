using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNation.Logic.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(CustomerDto customerDto);
        Task<Customer> RemoveCustomerAsync(int id);
    }
}
