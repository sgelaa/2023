
using Microsoft.EntityFrameworkCore;
using BookNation.DataAccess.Data;
using BookNation.DataAccess.Interfaces;
using BookNation.Logic.Interfaces;
using BookNation.Presenter.Interfaces;
using BookNation.Presenter.Services;

namespace BookNation.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            // "Server=(localdb)\\mssqllocaldb;Database=ArmsCore;Trusted_Connection=True;MultipleActiveResultSets=true"
            // "Server=(localdb)\\mssqllocaldb;Database=ArmsCoreGlobal;Trusted_Connection=True;MultipleActiveResultSets=true"
            services.AddDbContext<DataContext>(opt =>
            {
                // opt.UseSqlite(config.GetConnectionString("SqliteConnection"));
                // opt.UseSqlServer(config.GetConnectionString("SqlServerDarConnection"));
                opt.UseSqlServer(config.GetConnectionString("SqlServerLocalConnection"));
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            // services.AddScoped<ICustomerRepository, CustomerRepository>();
            // services.AddScoped<ICustomerService, CustomerService>();

            services.AddCors();
            
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}