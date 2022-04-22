using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Model.Response;

namespace GlobalBlue.VATCalculator.Api.Mapper;

public interface ICountryRateMapper
{
    CountryRateInfoResponse ToResponse(CountryRate entity);

    IEnumerable<CountryRateInfoResponse> ToResponse(IEnumerable<CountryRate>? entities);
}

public class CountryRateMapper : ICountryRateMapper
{
    public CountryRateInfoResponse ToResponse(CountryRate entity)
    {
        return new CountryRateInfoResponse()
        {
            Id = entity.Id,
            CountryId = entity.Country.Id,
            Rate = entity.Rate,
            RateTitle = entity.RateTitle
        };
    }

    public IEnumerable<CountryRateInfoResponse> ToResponse(IEnumerable<CountryRate>? entities)
    {
        return entities.Select(ToResponse);
    }
}