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

    
}