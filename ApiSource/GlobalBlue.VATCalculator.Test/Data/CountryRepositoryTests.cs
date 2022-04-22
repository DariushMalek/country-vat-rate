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

   
}