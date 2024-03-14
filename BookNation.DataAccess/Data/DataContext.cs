using BookNation.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookNation.DataAccess.Data
{
  public class DataContext : DbContext
  {
    public DataContext()
    { }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<AppUser> Users { get; set; }
  }
}