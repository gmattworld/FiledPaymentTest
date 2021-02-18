using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FiledPaymentTest.Core.Entities;
using FiledPaymentTest.Repository.IRepositories.Utilities;
using Microsoft.EntityFrameworkCore;

namespace FiledPaymentTest.Repository.Repositories.Utilities
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TId : class
    {

        private readonly DbContext Context;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            _ = Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<TEntity> GetAsync(TId id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public virtual async Task DeleteFinallyAsync(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }
    }
}