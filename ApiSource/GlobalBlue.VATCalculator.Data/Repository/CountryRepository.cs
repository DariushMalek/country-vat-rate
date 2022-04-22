using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model;
using GlobalBlue.VATCalculator.Model.Entities;

namespace GlobalBlue.VATCalculator.Data.Repository;

public class CountryRepository : EfRepository<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext? dbContext) : base(dbContext)
    {
    }
}