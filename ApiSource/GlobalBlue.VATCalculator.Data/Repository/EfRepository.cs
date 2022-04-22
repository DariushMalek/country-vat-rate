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

}