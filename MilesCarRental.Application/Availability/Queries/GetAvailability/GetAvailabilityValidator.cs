using FluentValidation;

namespace MilesCarRental.Application.Availability.Queries.GetAvailability;

public sealed class GetAvailabilityValidator : AbstractValidator<GetAvailabilityQuery>
{
    public GetAvailabilityValidator()
    {
        RuleFor(x => x.QuickSearch)
            .NotEmpty().WithMessage("quickSearch es requerido")
            .MaximumLength(500).WithMessage("quickSearch demasiado largo")
            .Matches("^[A-Za-z0-9+/=%-]+$").WithMessage("quickSearch debe ser base64/url-safe");
    }
}
