using MilesCarRental.Application.Abstractions;
using MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Infrastructure.InMemory;

public sealed class AvailabilityMockRepository : IAvailabilityMockRepository
{
    public IReadOnlyList<Agency> Agencies { get; }
    public IReadOnlyList<Agencyimages> Agencyimages { get; }
    public IReadOnlyList<Car> Cars { get; private set; }
    public IReadOnlyList<Currencyexchange> Currencyexchanges { get; }
    public IReadOnlyList<Destinationlocation> Destinationlocations { get; }
    public IReadOnlyList<Detaildiscount> Detaildiscounts { get; }
    public IReadOnlyList<Discountcode> Discountcodes { get; }
    public IReadOnlyList<Features> Features { get; }
    public IReadOnlyList<Filterinformation> Filterinformations { get; }
    public IReadOnlyList<Gallery> Galleries { get; }
    public IReadOnlyList<Inclusion> Inclusions { get; }
    public IReadOnlyList<Messageinformation> Messageinformations { get; }
    public IReadOnlyList<Originlocation> Originlocations { get; }
    public IReadOnlyList<Pagination> Paginations { get; }
    public IReadOnlyList<Paymentdata> Paymentdatas { get; }
    public IReadOnlyList<Phones> Phones { get; }
    public IReadOnlyList<Phones1> Phones1 { get; }
    public IReadOnlyList<Pickuplocation> Pickuplocations { get; }
    public IReadOnlyList<Rate> Rates { get; }
    public IReadOnlyList<Returnlocation> Returnlocations { get; }
    public IReadOnlyList<Schedule> Schedules { get; }
    public IReadOnlyList<Schedule1> Schedules1 { get; }
    public IReadOnlyList<Sortinformation> Sortinformations { get; }
    public IReadOnlyList<Tax> Taxes { get; }
    public IReadOnlyList<Timerwatch> Timerwatches { get; }
    public IReadOnlyList<Value> Values { get; }
    public IReadOnlyList<Vehicle> Vehicles { get; }

    private readonly IReadOnlyList<Vehicle> _allVehicles;

    private readonly Pickuplocation _mdePickup = new()
    {
        Code = "MDE01",
        Name = "Medellín Centro",
        Address = "Calle 1 #2-3",
        Phones = new Phones { Default = "+57 1 555 5555", DefaultUSA = "+1 305 555 5555", Location = "+57 4 444 4444" },
        City = "Medellín",
        CityCode = "MDE",
        State = "Antioquia",
        StateCode = "ANT",
        Country = "Colombia",
        CountryCode = "CO",
        Continent = "América",
        ContinentCode = "AM",
        Type = "CITY",
        Schedule = new Schedule { Sunday = "08:00-18:00" },
        FullSchedule = "L-V 08-18",
        Notes = Array.Empty<object>(),
        Distance = "0"
    };

    private readonly Returnlocation _bogReturn = new()
    {
        Code = "BOG01",
        Name = "Bogotá Centro",
        Address = "Calle 4 #5-6",
        Phones = new Phones1 { Default = "+57 1 111 1111", DefaultUSA = "+1 305 111 1111", Location = "+57 4 111 1111" },
        City = "Bogotá",
        CityCode = "BOG",
        State = "Cundinamarca",
        StateCode = "CUN",
        Country = "Colombia",
        CountryCode = "CO",
        Continent = "América",
        ContinentCode = "AM",
        Type = "CITY",
        Schedule = new Schedule1 { Sunday = "08:00-18:00" },
        FullSchedule = "L-V 08-18",
        Notes = Array.Empty<object>(),
        Distance = "0"
    };

    private readonly Pickuplocation _miaPickup = new()
    {
        Code = "MIA01",
        Name = "Miami Intl Airport",
        Address = "2100 NW 42nd Ave",
        Phones = new Phones { Default = "+1 305 555 1000", DefaultUSA = "+1 305 555 1000", Location = "+1 305 555 2000" },
        City = "Miami",
        CityCode = "MIA",
        State = "FL",
        StateCode = "FL",
        Country = "United States",
        CountryCode = "US",
        Continent = "North America",
        ContinentCode = "NA",
        Type = "AIRPORT",
        Schedule = new Schedule { Sunday = "00:00-23:59" },
        FullSchedule = "24/7",
        Notes = Array.Empty<object>(),
        Distance = "0"
    };

    private readonly Returnlocation _orlReturn = new()
    {
        Code = "ORL01",
        Name = "Orlando Intl Airport",
        Address = "1 Jeff Fuqua Blvd",
        Phones = new Phones1 { Default = "+1 407 555 1000", DefaultUSA = "+1 407 555 1000", Location = "+1 407 555 2000" },
        City = "Orlando",
        CityCode = "ORL",
        State = "FL",
        StateCode = "FL",
        Country = "United States",
        CountryCode = "US",
        Continent = "North America",
        ContinentCode = "NA",
        Type = "AIRPORT",
        Schedule = new Schedule1 { Sunday = "00:00-23:59" },
        FullSchedule = "24/7",
        Notes = Array.Empty<object>(),
        Distance = "0"
    };

    public AvailabilityMockRepository()
    {
        Agencyimages = new List<Agencyimages>
        {
            new Agencyimages
            {
                Logo = "https://cdn.example.com/logo.png",
                LogoAirport = "https://cdn.example.com/logo-airport.png",
                LogoPin = "https://cdn.example.com/logo-pin.png",
                LogoPinAirport = "https://cdn.example.com/logo-pin-airport.png",
                LogoNoBackground = "https://cdn.example.com/logo-nobg.png"
            }
        };

        Agencies = new List<Agency>
        {
            new Agency
            {
                AgencyCode = "HERTZ",
                AgencyFakeCode = null!,
                AgencyName = "Hertz",
                AgencyImages = Agencyimages.First(),
                AgencyRating = 4.5f,
                AccountCode = "ACC001",
                TourCode = null!,
                PartnerCode = null!
            }
        };

        Phones = new List<Phones> { new Phones { Default = "+57 1 555 5555", DefaultUSA = "+1 305 555 5555", Location = "+57 4 444 4444" } };
        Phones1 = new List<Phones1> { new Phones1 { Default = "+57 1 111 1111", DefaultUSA = "+1 305 111 1111", Location = "+57 4 111 1111" } };

        Galleries = new List<Gallery> { new Gallery { Id = 1, Image = "https://cdn.example.com/car.png", ImageWeb = "https://cdn.example.com/car-web.png", CarName = "Corolla" } };
        Currencyexchanges = new List<Currencyexchange> { new Currencyexchange { Currency = "USD", CurrencyExchangeValue = "1.0" } };
        Taxes = new List<Tax> { new Tax { Code = "VAT", Description = "Tax", Price = 0, Currency = "USD", PayementInRental = false } };

        Rates = new List<Rate> { new Rate { rateId = "R1", ratePeriod = "1", rateCategory = "1", rateTime = DateTime.UtcNow, rateCode = "B1" } };
        Inclusions = new List<Inclusion> { new Inclusion { CategoryCode = "INS", CategoryName = "Insurance", CategoryIcon = "i", Icon = "i", Name = "Basic coverage", Description = "Basic coverage", Additional = string.Empty, Code = "INS1", Value = new Value { Val = "Included", Name = "Insurance", Image = "https://cdn.example.com/ins.png" } } };

        Features = new List<Features> { new Features { FareOrigin = "COL", FareDestination = "COL", FareTemplateMessage = "Base fare", FareType = "BASE", FareMobile = true, FareDisplayAvailability = true, FarePackage = false, FareCompareInDetail = false, FareInsurance = false, FareTemplate = string.Empty, FirstPosition = false, SpecialRate = false, RecommendedRate = false, AllInclusiveRate = false, DollarDiamond = false, ThriftySapphire = false, AlamoMaxPromo = false, AlamoPromotion = false, OneFreeUpgrade = false, TwoFreeUpgrade = false, DriverUnder25 = false, IofBrasil = false, AvisBudgetBookingDiscount = false, UseLoyaltyCoupon = false, UseCancellationCoupon = false, IsWarningMarket = false, DoesApplyCustomerRetention = false, DealOfDay = false, UseUrlDiscount = false, IsFreeCancellation = true, IsEnableCoupon = true, IsSpecialOffer = false, IsBestValue = false, IsRecommended = true, IsMostRented = false, FareInsuranceTemplate = string.Empty } };

        _allVehicles = new List<Vehicle>
        {
            new Vehicle { Category = "Sedán", CategoryId = 1, CategoryPosition = 1, CategoryIcon = "sedan", SubCategory = Array.Empty<object>(), Class = "C", ClassId = 1, ClassImage = null!, Type = "Auto", Name = "Corolla", Brand = "Toyota", Group = "G1", SmallBags = 1, LargeBags = 1, TotalBags = 2, Passengers = 5, TypeTransmission = "AT", AirConditioner = true, SimilarModel = false, ExclusiveModel = false, LimitedMileage = false, ImageUrl = "https://cdn.example.com/corolla.png", ImageWeb = "https://cdn.example.com/corolla-web.png", Gallery = Galleries.ToArray() },
            new Vehicle { Category = "Hatchback", CategoryId = 1, CategoryPosition = 1, CategoryIcon = "hatch", SubCategory = Array.Empty<object>(), Class = "B", ClassId = 1, ClassImage = null!, Type = "Auto", Name = "Rio", Brand = "Kia", Group = "G1", SmallBags = 1, LargeBags = 1, TotalBags = 2, Passengers = 5, TypeTransmission = "MT", AirConditioner = true, SimilarModel = false, ExclusiveModel = false, LimitedMileage = false, ImageUrl = "https://cdn.example.com/rio.png", ImageWeb = "https://cdn.example.com/rio-web.png", Gallery = Galleries.ToArray() },
            new Vehicle { Category = "SUV", CategoryId = 2, CategoryPosition = 2, CategoryIcon = "suv", SubCategory = Array.Empty<object>(), Class = "D", ClassId = 2, ClassImage = null!, Type = "Auto", Name = "RAV4", Brand = "Toyota", Group = "G2", SmallBags = 2, LargeBags = 2, TotalBags = 4, Passengers = 5, TypeTransmission = "AT", AirConditioner = true, SimilarModel = false, ExclusiveModel = false, LimitedMileage = false, ImageUrl = "https://cdn.example.com/rav4.png", ImageWeb = "https://cdn.example.com/rav4-web.png", Gallery = Galleries.ToArray() },
            new Vehicle { Category = "Sport", CategoryId = 3, CategoryPosition = 3, CategoryIcon = "sport", SubCategory = Array.Empty<object>(), Class = "E", ClassId = 3, ClassImage = null!, Type = "Auto", Name = "Mustang", Brand = "Ford", Group = "G3", SmallBags = 1, LargeBags = 1, TotalBags = 2, Passengers = 4, TypeTransmission = "AT", AirConditioner = true, SimilarModel = false, ExclusiveModel = false, LimitedMileage = false, ImageUrl = "https://cdn.example.com/mustang.png", ImageWeb = "https://cdn.example.com/mustang-web.png", Gallery = Galleries.ToArray() },
            new Vehicle { Category = "SUV Fullsize", CategoryId = 4, CategoryPosition = 4, CategoryIcon = "suv", SubCategory = Array.Empty<object>(), Class = "F", ClassId = 4, ClassImage = null!, Type = "Auto", Name = "Tahoe", Brand = "Chevrolet", Group = "G4", SmallBags = 3, LargeBags = 3, TotalBags = 6, Passengers = 7, TypeTransmission = "AT", AirConditioner = true, SimilarModel = false, ExclusiveModel = false, LimitedMileage = false, ImageUrl = "https://cdn.example.com/tahoe.png", ImageWeb = "https://cdn.example.com/tahoe-web.png", Gallery = Galleries.ToArray() }
        };

        Vehicles = _allVehicles;
        Cars = BuildCars(DateTime.UtcNow, DateTime.UtcNow.AddDays(3), "Medellín", "CO", "Bogotá", "CO", "CO");

        Filterinformations = new List<Filterinformation>();
        Paginations = new List<Pagination> { new Pagination { totalItems = 1, totalPage = 1, numberItemPerPage = 20, numberPage = 1 } };
        Messageinformations = new List<Messageinformation>();
        Originlocations = new List<Originlocation> { new Originlocation { CountryCode = "CO", ContinentCode = "AM" } };
        Destinationlocations = new List<Destinationlocation> { new Destinationlocation { countryCode = "CO", continentCode = "AM" } };
        Timerwatches = new List<Timerwatch> { new Timerwatch { name = "search", time = "50", provider = "mock", typeTime = 0 } };
        Values = new List<Value> { new Value { Val = "V", Name = "N", Image = "https://cdn.example.com/v.png" } };
        Schedules = new List<Schedule> { new Schedule { Sunday = "08:00-18:00" } };
        Schedules1 = new List<Schedule1> { new Schedule1 { Sunday = "08:00-18:00" } };
        Sortinformations = new List<Sortinformation> { new Sortinformation { Name = "price" } };
        Paymentdatas = new List<Paymentdata> { new Paymentdata { CurrencyPayment = "USD" } };
    }

    private static string ComposeMarket(string pickupCountryIso, string customerCountryIso)
        => $"{pickupCountryIso}-{customerCountryIso}";

    private static Features BuildFeatures(string originIso, string destIso)
        => new Features
        {
            FareOrigin = originIso,
            FareDestination = destIso,
            FareTemplateMessage = "Base fare",
            FareType = "BASE",
            FareMobile = true,
            FareDisplayAvailability = true,
            FarePackage = false,
            FareCompareInDetail = false,
            FareInsurance = false,
            FareTemplate = string.Empty,
            FirstPosition = false,
            SpecialRate = false,
            RecommendedRate = false,
            AllInclusiveRate = false,
            DollarDiamond = false,
            ThriftySapphire = false,
            AlamoMaxPromo = false,
            AlamoPromotion = false,
            OneFreeUpgrade = false,
            TwoFreeUpgrade = false,
            DriverUnder25 = false,
            IofBrasil = false,
            AvisBudgetBookingDiscount = false,
            UseLoyaltyCoupon = false,
            UseCancellationCoupon = false,
            IsWarningMarket = false,
            DoesApplyCustomerRetention = false,
            DealOfDay = false,
            UseUrlDiscount = false,
            IsFreeCancellation = true,
            IsEnableCoupon = true,
            IsSpecialOffer = false,
            IsBestValue = false,
            IsRecommended = true,
            IsMostRented = false,
            FareInsuranceTemplate = string.Empty
        };

    private static (string currency, float fx, float taxRate) ResolveCurrencyAndTax(string originIso, string destIso)
    {
        var market = $"{originIso}-{destIso}";
        return market switch
        {
            "CO-CO" => ("COP", 4000f, 0.19f),
            "CO-US" => ("USD", 1f, 0.08f),
            "US-US" => ("USD", 1f, 0.08f),
            _ => ("USD", 1f, 0.08f)
        };
    }

    private IReadOnlyList<Car> BuildCars(DateTime pickup, DateTime @return, string pickupCity, string pickupCountryIso, string returnCity, string returnCountryIso, string customerCountryIso)
    {
        var originIso = pickupCountryIso.ToUpperInvariant();
        var destIso = customerCountryIso.ToUpperInvariant();
        var market = ComposeMarket(originIso, destIso);

        var pickupLoc = originIso == "US" ? _miaPickup : _mdePickup;
        var returnLoc = (returnCountryIso?.ToUpperInvariant() == "US") ? _orlReturn : _bogReturn;

        IEnumerable<Vehicle> allowed = _allVehicles;
        switch (market)
        {
            case "CO-CO":
                allowed = _allVehicles.Where(v => v.Name is "Corolla" or "RAV4");
                break;
            case "CO-US":
                allowed = _allVehicles.Where(v => v.Name is "Corolla" or "Rio");
                break;
            case "US-US":
                allowed = _allVehicles.Where(v => v.Name is "Mustang" or "Tahoe");
                break;
            default:
                allowed = Enumerable.Empty<Vehicle>();
                break;
        }

        float BasePriceUsd(Vehicle v) => v.Name switch
        {
            "Mustang" => 220f,
            "Tahoe" => 260f,
            "RAV4" => 180f,
            "Rio" => 90f,
            _ => 120f
        };

        var featureForMarket = BuildFeatures(originIso, destIso);
        var (currency, fx, taxRate) = ResolveCurrencyAndTax(originIso, destIso);

        var cars = allowed.Select(v =>
        {
            var baseUsd = BasePriceUsd(v);
            var baseLocal = baseUsd * fx;
            var tax = baseLocal * taxRate;
            var total = baseLocal + tax;

            return new Car
            {
                ItemCode = $"ITEM-{v.Name}",
                PriceDestination = baseLocal,
                Agency = Agencies.First(),
                Features = featureForMarket,
                PickupLocation = pickupLoc,
                ReturnLocation = returnLoc,
                PickupDateTime = pickup,
                ReturnDateTime = @return,
                Vehicle = v,
                PaymentType = "Prepaid",
                Code = $"CODE-{v.Name}",
                Description = $"{v.Brand} {v.Name}",
                Image = v.ImageUrl,
                DiscountCode = new Discountcode { providerCode = "HERTZ", alternativeProviderCode = "HTZ", name = "Promo10", rateQualifier = "RQ", discountNumber = "10", tourNumber = "T1", promotionCode = "PROMO10", motorCode = "M1", code = "D1", agencyCode = "AG1", bookingSource = "WEB", paymentType = "PP" },
                FarePaymentName = currency,
                BasePriceExchangeBase = baseLocal,
                TotalPriceExchangeBase = total,
                CurrencyExchange = new [] { new Currencyexchange { Currency = currency, CurrencyExchangeValue = fx.ToString("0.####") } },
                Currency = currency,
                Taxes = new [] { new Tax { Code = "VAT", Description = "Tax", Price = tax, Currency = currency, PayementInRental = false } },
                ProviderCode = "HERTZ",
                Rate = Rates.First(),
                VehicleTypeOwner = "OWN",
                Inclusions = Inclusions.ToArray(),
                PaymentAvailable = Array.Empty<object>(),
                ExtrasCar = Array.Empty<object>(),
                ExtrasFare = Array.Empty<object>(),
                Equipment = Array.Empty<object>(),
                Comments = Array.Empty<object>(),
                DetailDiscount = Array.Empty<Detaildiscount>(),
                ChangePrice = "0",
                PaymentData = new Paymentdata { CurrencyPayment = currency },
                BasePrice = baseLocal,
                Subtotal = baseLocal,
                BasePriceDaily = (float)Math.Round(baseLocal / Math.Max(1, (@return - pickup).TotalDays), 2),
                TotalPriceDaily = (float)Math.Round(total / Math.Max(1, (@return - pickup).TotalDays), 2),
                BasePriceStrike = 0,
                TotalPrice = total,
                TaxPrice = tax,
                RateConvertion = 1,
                RateCurrency = 1,
                RateBasePrice = baseLocal,
                RealBasePrice = baseLocal,
                RealTotalPrice = total,
                RentalDuration = (int)Math.Ceiling((@return - pickup).TotalDays),
                FormatPrecision = 2,
                StrikeDiscount = 0
            };
        }).ToList();

        return cars;
    }

    public Rootobject BuildRootobjectSample(
        DateTime? pickupDate = null,
        DateTime? returnDate = null,
        string? pickupCity = null,
        string? pickupCountryIso = null,
        string? returnCity = null,
        string? returnCountryIso = null,
        string? customerCountryIso = null)
    {
        var pick = pickupDate ?? DateTime.UtcNow;
        var ret = returnDate ?? DateTime.UtcNow.AddDays(3);
        var pCity = string.IsNullOrWhiteSpace(pickupCity) ? "Medellín" : pickupCity;
        var rCity = string.IsNullOrWhiteSpace(returnCity) ? "Bogotá" : returnCity;
        var pCountry = string.IsNullOrWhiteSpace(pickupCountryIso) ? "CO" : pickupCountryIso.ToUpperInvariant();
        var rCountry = string.IsNullOrWhiteSpace(returnCountryIso) ? pCountry : returnCountryIso.ToUpperInvariant();
        var cCountry = string.IsNullOrWhiteSpace(customerCountryIso) ? pCountry : customerCountryIso.ToUpperInvariant();

        Cars = BuildCars(pick, ret, pCity!, pCountry!, rCity!, rCountry!, cCountry!);

        return new Rootobject
        {
            Pagination = Paginations.First(),
            FilterApplied = new { },
            FilterInformation = Filterinformations.ToArray(),
            SortApplied = new { },
            SortInformation = Sortinformations.ToArray(),
            Method = "mock",
            Cars = Cars.ToArray(),
            HasToShowSoldOut = false,
            Traveler = new { },
            Target = 0,
            Timerwatch = Timerwatches.ToArray(),
            MessageInformation = Messageinformations.ToArray(),
            LogRules = new { },
            IsLandingPage = false,
            OriginLocation = new Originlocation { CountryCode = pCountry, ContinentCode = pCountry == "US" ? "NA" : "AM" },
            DestinationLocation = new Destinationlocation { countryCode = rCountry, continentCode = rCountry == "US" ? "NA" : "AM" },
            IdSession = Guid.NewGuid().ToString(),
            TargetApply = new[] { ComposeMarket(pCountry!, cCountry!) },
            RuleInformation = new { },
            ShowLogRules = false
        };
    }
}
