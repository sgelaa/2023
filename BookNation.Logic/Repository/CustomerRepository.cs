using BookNation.DataAccess.Data;
using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Logic.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context  = context;
        }

        public async Task<Customer> AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                City = customerDto.City,
                DateAdded = DateTime.Now
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                City = customer.City,
                DateAdded = customer.DateAdded
            };
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers
                .Where(customer => customer.Id == id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> RemoveCustomerAsync(int removeId)
        {
            var customer = this.GetCustomerAsync(removeId);

            _context.Customers.Remove(customer.Result);
            await _context.SaveChangesAsync();

            return new Customer
            {
                Id = customer.Result.Id,
                Name = customer.Result.Name,
                City = customer.Result.City,
                DateAdded = customer.Result.DateAdded
            };
        }
    }
}