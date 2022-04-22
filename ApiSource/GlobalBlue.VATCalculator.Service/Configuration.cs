using GlobalBlue.VATCalculator.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalBlue.VATCalculator.Service;

public static class Configuration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ICountryService, CountryService>()
            .AddTransient<ICountryRateService, CountryRateService>();
    }
}