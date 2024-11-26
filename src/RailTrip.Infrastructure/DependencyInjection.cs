using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RailTrip.Domain.Abstractions;
using RailTrip.Infrastructure.Repositories;
using System.Data;

namespace RailTrip.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // database
            services.AddDbContext<ApplicationDbContext>(builder => builder.UseNpgsql(configuration.GetConnectionString("Application")));

            services.AddScoped<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IDbConnection>(factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());


            // services
            services.AddScoped<IRailOperatorRepository, RailOperatorRepository>();

            return services;
        }
    }
}
