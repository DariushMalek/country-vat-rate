using GlobalBlue.VATCalculator.Model;
using GlobalBlue.VATCalculator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalBlue.VATCalculator.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Country> Countries { get; set; }

    public DbSet<CountryRate> CountryRates { get; set; }
}