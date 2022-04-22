using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Service.Abstractions;

namespace GlobalBlue.VATCalculator.Service;

public class CountryService : ServiceBase, ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await _countryRepository.ListAllAsync();
    }
}