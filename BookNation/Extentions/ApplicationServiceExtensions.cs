
using BookNation.Data;
using BookNation.DataAccess.Data;
using BookNation.DataAccess.Interfaces;
using BookNation.Interfaces;
using BookNation.Logic;
using BookNation.Services;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            //  "DefaultConnection": "Data source=booknation.db"
            // services.AddDbContext<DataContext>(opt =>
            // {
            //     opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            // });
            services.AddDbContext<AppDataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}