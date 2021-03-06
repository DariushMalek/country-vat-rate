using GlobalBlue.VATCalculator.Model.Entities;

namespace GlobalBlue.VATCalculator.Service.Abstractions;

public interface ICountryRateService : IServiceBase
{
    Task<IEnumerable<CountryRate>?> GetCountryCurrentRates(int countryId);
}