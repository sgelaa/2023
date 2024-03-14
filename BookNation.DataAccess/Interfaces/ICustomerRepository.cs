using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;

namespace BookNation.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(CustomerDto customerDto);
        Task<Customer> RemoveCustomerAsync(int removeId);
    }
}