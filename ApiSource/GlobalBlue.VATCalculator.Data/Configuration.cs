using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalBlue.VATCalculator.Data;

public static class Configuration
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, string dbConnectionString)
    {
        void ConfigureDbContext(DbContextOptionsBuilder o) => o.UseSqlite(dbConnectionString);

        return services
            .AddDbContext<AppDbContext>(ConfigureDbContext);
    }
}