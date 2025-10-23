using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Application.Behaviors;
using MilesCarRental.Application.Configuration;

namespace MilesCarRental.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly
            );

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}

