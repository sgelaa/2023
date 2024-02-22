using BookNation.DataAccess.Entities;

namespace BookNation.Logic
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
