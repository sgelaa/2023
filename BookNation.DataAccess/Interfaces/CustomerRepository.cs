using BookNation.DataAccess.Data;
using BookNation.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNation.DataAccess.Interfaces
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDataContext  _appDataContext;
        public CustomerRepository(AppDataContext appDataContext) {
            _appDataContext = appDataContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _appDataContext.Customers.ToListAsync();
        }
    }
}
