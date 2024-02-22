using BookNation.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNation.Logic
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
