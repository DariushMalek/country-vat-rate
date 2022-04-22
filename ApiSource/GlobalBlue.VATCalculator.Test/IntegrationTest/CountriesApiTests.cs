
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Test.IntegrationTest.Base;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.IntegrationTest;

public class CountriesApiTests : TestBase
{
    private const string BaseUrl = "api/";

    public CountriesApiTests(ApiFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll_EndpointsReturnSuccessAndCorrectContentType()
    {
        var result = await GetCountriesAsync();

        result.Should().NotBeNull();
        result.Should().HaveCountGreaterThan(1);
    }

    public async Task<IEnumerable<Country>> GetCountriesAsync()
    {
        return await GetRequest<IEnumerable<Country>>($"{BaseUrl}countries");
    }
}