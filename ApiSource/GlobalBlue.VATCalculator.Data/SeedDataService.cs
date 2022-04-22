using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model.Entities;

namespace GlobalBlue.VATCalculator.Data;

public class SeedDataService : IDisposable
{
    private readonly ICountryRepository _countryRepository;

    private readonly ICountryRateRepository _countryRateRepository;

    private readonly AppDbContext _dbContext;

    public SeedDataService(ICountryRepository countryRepository, ICountryRateRepository countryRateRepository, AppDbContext dbContext)
    {
        _countryRepository = countryRepository;
        _countryRateRepository = countryRateRepository;
        _dbContext = dbContext;
    }

    public async Task SeedData()
    {
        if (await _dbContext.Database.EnsureCreatedAsync())
        {
            await AddAustriaInfo();
            await AddGermanyInfo();
            await AddUKInfo();
        }
    }

    private async Task AddAustriaInfo()
    {
        var country = await _countryRepository.AddAsync(new Country()
        {
            CountryName = "Austria",
            IsDefault = true
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 10,
            RateTitle = "10%"
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 13,
            RateTitle = "13%"
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 20,
            RateTitle = "20%"
        });
    }

    private async Task AddGermanyInfo()
    {
        var country = await _countryRepository.AddAsync(new Country()
        {
            CountryName = "Germany",
            IsDefault = false
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 5,
            RateTitle = "5%"
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 7,
            RateTitle = "7%"
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 19,
            RateTitle = "19%"
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 16,
            RateTitle = "16%"
        });
    }

    private async Task AddUKInfo()
    {
        var country = await _countryRepository.AddAsync(new Country()
        {
            CountryName = "United Kingdom",
            IsDefault = false
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 5,
            RateTitle = "5%"
        });

        await _countryRateRepository.AddAsync(new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 20,
            RateTitle = "20%"
        });
    }

    public void Dispose() => _dbContext.Dispose();
}