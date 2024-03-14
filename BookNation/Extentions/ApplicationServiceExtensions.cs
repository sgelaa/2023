
using BookNation.Data;
using BookNation.DataAccess.Data;
using BookNation.Interfaces;
using BookNation.Logic.Interfaces;
using BookNation.Logic.Repository;
using BookNation.Logic.Services;
using BookNation.Services;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<DataAccess.Data.DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("SqliteConnection"));
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}