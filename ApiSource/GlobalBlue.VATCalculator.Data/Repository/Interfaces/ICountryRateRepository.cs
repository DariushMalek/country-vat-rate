using GlobalBlue.VATCalculator.Model;
using GlobalBlue.VATCalculator.Model.Entities;

namespace GlobalBlue.VATCalculator.Data.Repository.Interfaces;

public  interface ICountryRateRepository : IAsyncRepository<CountryRate>
{
    Task<IEnumerable<CountryRate>?> GetByCountryAndDate(int countryId, DateTime dateOfRate);
}