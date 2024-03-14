using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
