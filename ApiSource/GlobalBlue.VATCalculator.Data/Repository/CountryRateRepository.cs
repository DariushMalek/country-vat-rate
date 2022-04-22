using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model;
using GlobalBlue.VATCalculator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalBlue.VATCalculator.Data.Repository;

public class CountryRateRepository : EfRepository<CountryRate>, ICountryRateRepository
{
    public CountryRateRepository(AppDbContext? dbContext) : base(dbContext)
    {
    }
}