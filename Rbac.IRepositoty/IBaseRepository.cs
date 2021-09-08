using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rbac.IRepositoty
{
    public interface IBaseRepository<TEntity,TKey>
        where TEntity:class,new()
        where TKey:struct
    {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task BulkDeleteAsync(IEnumerable<TEntity> entities);
        Task BulkInsertAsync(IEnumerable<TEntity> entitys);
        Task<int> CreateAsync(IEnumerable<TEntity> entitys);
        Task<int> CreateAsync(TEntity entity);
        Task DeleteAsync(Expression<Func<TEntity, bool>> Condition);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteAsync(TKey key);
        Task<TEntity> FindAsync(TKey key);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> Condition = null);
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> Condition = null);
        (int, List<TEntity>) PagedList(Expression<Func<TEntity, TKey>> orderBy, int PageIndex = 1, int PageSize = 10, Expression<Func<TEntity, bool>> Condition = null);
        Task SingleDeleteAsync(TEntity entity);
        void UpdateAsync(Expression<Func<TEntity, bool>> Condition, Expression<Func<TEntity, TEntity>> updateExpression);
    }
}
