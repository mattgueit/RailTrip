
using RailTrip.Application;
using RailTrip.Infrastructure;
using RailTrip.Presentation;
using RailTrip.WebApi.Middleware;
using Serilog;

namespace RailTrip.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register controllers because they're specified in the 
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(RailTrip.Presentation.DependencyInjection).Assembly);

            // Register services in each project (except Domain - it doesn't need one).
            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddPresentation();

            builder.Services.AddTransient<ExceptionHandlingMiddleware>();

            // Register serilog
            builder.Host.UseSerilog((context, configuration) => 
                configuration.ReadFrom.Configuration(context.Configuration)
            );

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Log HTTP requests
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
