using System.Linq.Expressions;
using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model;
using GlobalBlue.VATCalculator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalBlue.VATCalculator.Data.Repository;

public abstract class EfRepository<TEntity> : IAsyncRepository<TEntity> 
    where TEntity : EntityBase
{
    protected readonly AppDbContext? DbContext;

    protected readonly DbSet<TEntity> DbSet;

    protected EfRepository(AppDbContext? dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> ListAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual IQueryable<TEntity>? GetByCriteria(Expression<Func<TEntity, bool>> criteria, bool includeAll = false)
    {
        var query = DbSet.AsQueryable();
        if (!includeAll)
        {
            return query.Where(criteria);
        }

        var navigators = DbContext.Model.FindEntityType(typeof(TEntity))
            ?.GetDerivedTypesInclusive()
            .SelectMany(type => type.GetNavigations())
            .Distinct();

        if (navigators != null)
        {
            query = navigators.Aggregate(query, (current, property) => current.Include(property.Name));
        }

        return query.Where(criteria);
    }
}