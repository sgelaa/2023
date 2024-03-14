using BookNation.DataAccess.Data;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Logic.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext  _appDataContext;
        public CustomerRepository(DataContext appDataContext) {
            _appDataContext = appDataContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _appDataContext.Customers.ToListAsync();
        }
    }
}
