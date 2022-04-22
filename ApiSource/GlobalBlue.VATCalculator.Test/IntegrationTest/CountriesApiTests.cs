
using GlobalBlue.VATCalculator.Test.IntegrationTest.Base;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.IntegrationTest;

public class CountriesApiTests : TestBase
{
    private const string BaseUrl = "api/";

    public CountriesApiTests(ApiFactory factory) : base(factory)
    {
    }
}