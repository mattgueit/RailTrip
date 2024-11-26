using Microsoft.Extensions.DependencyInjection;

namespace RailTrip.Presentation
{
    // Note: this is also being used as an assembly marker to register controllers on startup.
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            return services;
        }
    }
}
