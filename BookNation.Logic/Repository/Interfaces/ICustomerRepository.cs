using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(CustomerDto customerDto);
        Task<Customer> RemoveCustomerAsync(int removeId);
    }
}