using System.Linq.Expressions;
using GlobalBlue.VATCalculator.Model;
using GlobalBlue.VATCalculator.Model.Entities;

namespace GlobalBlue.VATCalculator.Data.Repository.Interfaces;

public interface IAsyncRepository<TEntity> 
    where TEntity : EntityBase
{

}