using BookNation.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookNation.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
