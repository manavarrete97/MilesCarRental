using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Application.Abstractions;
using MilesCarRental.Infrastructure.Persistence;
using MilesCarRental.Infrastructure.Repositories;
using MilesCarRental.Infrastructure.InMemory;
using AutoMapper;
using MilesCarRental.Infrastructure.External.Miles.Mapping;

namespace MilesCarRental.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // EF Core InMemory for demo
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("MilesCarRentalDb"));

            // Repositories
            services.AddScoped<IVehicleReadRepository, VehicleReadRepository>();
            services.AddScoped<ILocationReadRepository, LocationReadRepository>();

            // Mock data for availability response types
            services.AddSingleton<IAvailabilityMockRepository, AvailabilityMockRepository>();

            // AutoMapper profiles for provider -> domain mapping
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MilesAvailabilityProfile>();
            }, typeof(MilesAvailabilityProfile).Assembly);

            return services;
        }
    }
}
