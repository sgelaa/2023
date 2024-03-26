
using Microsoft.EntityFrameworkCore;
using BookNation.DataAccess.Data;
using BookNation.Presenter.Interfaces;
using BookNation.Presenter.Services;
using BookNation.Logic.Services;
using BookNation.Logic.Services.Interfaces;
using BookNation.Logic.Repository.Interfaces;
using BookNation.Logic.Repository;
using BookNation.Logic.Interfaces;

namespace BookNation.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                // opt.UseSqlite(config.GetConnectionString("SqliteConnection"));
                opt.UseSqlServer(config.GetConnectionString("SqlServerLocalConnection"));
            });

            // repo
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            // service
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddCors();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}