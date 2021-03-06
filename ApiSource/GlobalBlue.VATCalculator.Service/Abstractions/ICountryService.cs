using GlobalBlue.VATCalculator.Model.Entities;

namespace GlobalBlue.VATCalculator.Service.Abstractions;

public interface ICountryService : IServiceBase
{
    Task<IEnumerable<Country>> GetAllCountries();
}