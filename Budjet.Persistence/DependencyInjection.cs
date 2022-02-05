using Budjet.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Budjet.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddDbContext<BudjetDbContext>(opts =>
               opts.UseSqlServer(configuration.GetConnectionString("SqlConnection"), b => b.MigrationsAssembly("Budjet.WebApi")));
        

        services.AddScoped<IBudjetDbContext>(provider =>
                provider.GetService<BudjetDbContext>());

            return services;
        }
    }
}
