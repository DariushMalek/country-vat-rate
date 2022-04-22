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

    public async Task<IEnumerable<CountryRate>?> GetByCountryAndDate(int countryId, DateTime dateOfRate)
    {
        return await GetByCriteria(n =>
            n.Country.Id == countryId && n.FromDate <= dateOfRate && (n.ToDate >= dateOfRate || n.ToDate == null), true)!.ToListAsync();
    }
}