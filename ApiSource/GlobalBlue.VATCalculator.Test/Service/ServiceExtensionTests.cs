using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using GlobalBlue.VATCalculator.Service;
using GlobalBlue.VATCalculator.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.Service;

public class ServiceExtensionTests
{
    [Fact]
    private void RegisterServicesTest()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();

        //Act
        serviceCollection.AddBusinessServices();

        //Assert
        var services = serviceCollection.ToImmutableArray();

        services.Any(x => x.ServiceType == typeof(ICountryService)).Should().BeTrue();

        services.Any(x => x.ServiceType == typeof(ICountryRateService)).Should().BeTrue();
    }
}