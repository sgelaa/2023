using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
