using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GlobalBlue.VATCalculator.Test.IntegrationTest.Base;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.IntegrationTest;

public class TestBase : IClassFixture<ApiFactory>
{
    protected readonly ApiFactory Factory;

    protected readonly HttpClient Client;

    public TestBase(ApiFactory factory)
    {
        Factory = factory;
        Client = Factory.CreateClient();
    }

    protected async Task<T> GetRequest<T>(string url)
    {
        var response = await Client.GetAsync(url);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        return await response.ReadAsJson<T>();
    }
}