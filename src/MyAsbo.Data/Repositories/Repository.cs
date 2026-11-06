using Microsoft.EntityFrameworkCore;
using MyAsbo.Data.DbContexts;
using MyAsbo.Data.IRepositories;
using MyAsbo.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? predicate = null)
          => predicate is null ? _dbSet : _dbSet.Where(predicate);

        public async Task<TEntity?> SelectAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
         => _dbSet.AnyAsync(predicate);

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            return entry.Entity;
        }

        public TEntity Update(TEntity entity)
           => _dbSet.Update(entity).Entity;

        public Task SaveChangesAsync()
         => _dbContext.SaveChangesAsync();






    }
}
