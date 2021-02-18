using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FiledPaymentTest.Repository.IRepositories.Utilities
{
    public interface IBaseRepository<TEntity, TId>
    {
        /// <summary>
        /// Create new record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Find get records using predicates
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TId id);

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity obj);

        /// <summary>
        /// Delete Record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task DeleteFinallyAsync(TEntity obj);
    }
}