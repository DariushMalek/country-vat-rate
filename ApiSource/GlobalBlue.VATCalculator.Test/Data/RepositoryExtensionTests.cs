using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using GlobalBlue.VATCalculator.Data;
using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.Data;

public class RepositoryExtensionTests
{
    [Fact]
    private void RegisterRepositoriesTest()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        const string connectionString = $"Data Source = TestAppDb.db";

        //Act
        serviceCollection.AddDataServices(connectionString);

        //Assert
        var services = serviceCollection.ToImmutableArray();

        services.Any(x => x.ServiceType == typeof(ICountryRepository)).Should().BeTrue();

        services.Any(x => x.ServiceType == typeof(ICountryRateRepository)).Should().BeTrue();
    }
}