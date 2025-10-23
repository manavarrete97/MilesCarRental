using AutoMapper;
using MilesCarRental.Infrastructure.External.Miles.ProviderDtos;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Infrastructure.External.Miles.Mapping;

public sealed class MilesAvailabilityProfile : Profile
{
    public MilesAvailabilityProfile()
    {
        CreateMap<AvailabilityResponseProvider, Res.Rootobject>()
            .ForMember(d => d.Cars, o => o.MapFrom(s => s.Cars));

        CreateMap<CarProvider, Res.Car>()
            .ForMember(d => d.PickupLocation, o => o.MapFrom(s => s.PickupLocation))
            .ForMember(d => d.ReturnLocation, o => o.MapFrom(s => s.ReturnLocation))
            .ForMember(d => d.Vehicle, o => o.MapFrom(s => s.Vehicle))
            .ForMember(d => d.TotalPrice, o => o.MapFrom(s => (float)s.TotalPrice))
            .ForMember(d => d.Currency, o => o.MapFrom(s => s.Currency))
            .ForMember(d => d.Agency, o => o.MapFrom(s => s.Agency));

        CreateMap<LocationProvider, Res.Pickuplocation>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.City, o => o.MapFrom(s => s.City))
            .ForMember(d => d.Country, o => o.MapFrom(s => s.Country))
            .ForMember(d => d.Distance, o => o.MapFrom(s => s.Distance));

        CreateMap<LocationProvider, Res.Returnlocation>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.City, o => o.MapFrom(s => s.City))
            .ForMember(d => d.Country, o => o.MapFrom(s => s.Country))
            .ForMember(d => d.Distance, o => o.MapFrom(s => s.Distance));

        CreateMap<VehicleProvider, Res.Vehicle>()
            .ForMember(d => d.Category, o => o.MapFrom(s => s.Category))
            .ForMember(d => d.Class, o => o.MapFrom(s => s.Class))
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand))
            .ForMember(d => d.Passengers, o => o.MapFrom(s => s.Passengers));

        CreateMap<AgencyProvider, Res.Agency>()
            .ForMember(d => d.AgencyCode, o => o.MapFrom(s => s.AgencyCode))
            .ForMember(d => d.AgencyName, o => o.MapFrom(s => s.AgencyName))
            .ForMember(d => d.AgencyImages, o => o.Ignore())
            .ForMember(d => d.AgencyRating, o => o.Ignore())
            .ForMember(d => d.AccountCode, o => o.Ignore())
            .ForMember(d => d.AgencyFakeCode, o => o.Ignore())
            .ForMember(d => d.TourCode, o => o.Ignore())
            .ForMember(d => d.PartnerCode, o => o.Ignore());
    }
}
