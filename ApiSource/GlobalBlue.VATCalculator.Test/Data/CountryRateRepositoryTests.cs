using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GlobalBlue.VATCalculator.Data.Repository;
using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Test.Data.Fixtures;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.Data;

[Collection("SqlLiteDbContext collection")]
public class CountryRateRepositoryTests
{
    private readonly ICountryRateRepository _countryRateRepository;

    private readonly ICountryRepository _countryRepository;

    public CountryRateRepositoryTests(SqlLiteDbContextFixture dbContextFixture)
    {
        _countryRepository = new CountryRepository(dbContextFixture.Context);

        _countryRateRepository = new CountryRateRepository(dbContextFixture.Context);
    }

    [Fact]
    public async Task AddAsync_ShouldReturn_EntityWithId()
    {
        var newCountry = new Country()
        {
            CountryName = "Austria",
            IsDefault = true
        };

        var country = await _countryRepository.AddAsync(newCountry);

        var newRate = new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 5,
            RateTitle = "5%"
        };

        var result = await _countryRateRepository.AddAsync(newRate);

        result.Id.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetByCountryAndDate_ShouldReturn_CountryRateWith_ValidDate()
    {
        var newCountry = new Country()
        {
            CountryName = "Austria",
            IsDefault = true
        };

        var country = await _countryRepository.AddAsync(newCountry);

        var newRate = new CountryRate()
        {
            Country = country,
            FromDate = DateTime.Now,
            ToDate = null,
            Rate = 5,
            RateTitle = "5%"
        };

        var rate = await _countryRateRepository.AddAsync(newRate);

        var result = await _countryRateRepository.GetByCountryAndDate(country.Id, DateTime.Now);

        result.Should().HaveCount(1);
        result.FirstOrDefault().Id.Should().Be(rate.Id);
    }
}