using MyAsbo.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? predicate = null);
        Task<TEntity?> SelectAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task SaveChangesAsync();


    }
}
