using System.Threading.Tasks;
using FluentAssertions;
using GlobalBlue.VATCalculator.Data.Repository;
using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Test.Data.Fixtures;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.Data;

[Collection("SqlLiteDbContext collection")]
public class CountryRepositoryTests
{
    private readonly ICountryRepository _countryRepository;

    public CountryRepositoryTests(SqlLiteDbContextFixture dbContextFixture)
    {
        _countryRepository = new CountryRepository(dbContextFixture.Context);
    }

    [Fact]
    public async Task AddAsync_ShouldReturn_EntityWithId()
    {
        var newCountry = new Country()
        {
            CountryName = "Austria",
            IsDefault = true
        };

        var result = await _countryRepository.AddAsync(newCountry);

        result.Id.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task ListAllAsync_ShouldReturn_AllEntities()
    {
        var austria = new Country()
        {
            CountryName = "UK",
            IsDefault = false
        };
        var germany = new Country()
        {
            CountryName = "Germany",
            IsDefault = false
        };

        await _countryRepository.AddAsync(austria);
        await _countryRepository.AddAsync(germany);

        var result = await _countryRepository.ListAllAsync();

        result.Should().NotBeNull();
        result.Should().HaveCountGreaterThan(2);
    }
}