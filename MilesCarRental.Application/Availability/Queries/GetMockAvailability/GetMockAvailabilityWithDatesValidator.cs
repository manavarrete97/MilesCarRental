using FluentValidation;

namespace MilesCarRental.Application.Availability.Queries.GetMockAvailability;

public sealed class GetMockAvailabilityWithDatesValidator : AbstractValidator<GetMockAvailabilityWithDatesQuery>
{
    public GetMockAvailabilityWithDatesValidator()
    {
        RuleFor(x => x.PickupDate)
            .NotEmpty().WithMessage("pickupDate es requerido")
            .LessThan(x => x.ReturnDate).WithMessage("pickupDate debe ser menor que returnDate");

        RuleFor(x => x.ReturnDate)
            .NotEmpty().WithMessage("returnDate es requerido");

        RuleFor(x => x.PickupCity)
            .NotEmpty().WithMessage("pickupCity es requerido")
            .MaximumLength(100).WithMessage("pickupCity demasiado largo");

        RuleFor(x => x.ReturnCity)
            .NotEmpty().WithMessage("returnCity es requerido")
            .MaximumLength(100).WithMessage("returnCity demasiado largo");

        RuleFor(x => x.PickupCountryIso)
            .NotEmpty().WithMessage("pickupCountry es requerido")
            .Matches("^[A-Za-z]{2}$").WithMessage("pickupCountry debe ser ISO alpha-2 (e.g., CO, US)");

        RuleFor(x => x.ReturnCountryIso)
            .NotEmpty().WithMessage("returnCountry es requerido")
            .Matches("^[A-Za-z]{2}$").WithMessage("returnCountry debe ser ISO alpha-2 (e.g., CO, US)");

        RuleFor(x => x.CustomerCountryIso)
            .NotEmpty().WithMessage("customerCountry es requerido")
            .Matches("^[A-Za-z]{2}$").WithMessage("customerCountry debe ser ISO alpha-2 (e.g., CO, US)");
    }
}
