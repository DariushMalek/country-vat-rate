namespace GlobalBlue.VATCalculator.Api.Mapper;

public static class Configuration
{
    public static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ICountryRateMapper, CountryRateMapper>();
    }
}