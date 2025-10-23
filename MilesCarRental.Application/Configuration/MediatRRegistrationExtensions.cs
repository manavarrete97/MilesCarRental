using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MilesCarRental.Application.Configuration
{
    public static class MediatRRegistrationExtensions
    {
        public static IServiceCollection RegisterServicesFromAssemblies(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
                assemblies = new[] { Assembly.GetExecutingAssembly() };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

            return services;
        }
    }
}

