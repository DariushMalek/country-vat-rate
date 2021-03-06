using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Service.Abstractions;

namespace GlobalBlue.VATCalculator.Service;

public class CountryRateService : ServiceBase, ICountryRateService
{
    private readonly ICountryRateRepository _countryVatRepository;

    public CountryRateService(ICountryRateRepository countryVatRepository)
    {
        _countryVatRepository = countryVatRepository;
    }

    public async Task<IEnumerable<CountryRate>?> GetCountryCurrentRates(int countryId)
    {
        return await _countryVatRepository.GetByCountryAndDate(countryId, DateTime.Now);
    }

}