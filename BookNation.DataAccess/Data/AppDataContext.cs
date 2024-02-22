using BookNation.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookNation.DataAccess.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) 
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
