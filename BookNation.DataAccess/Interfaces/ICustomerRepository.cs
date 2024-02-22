using BookNation.DataAccess.Entities;

namespace BookNation.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
