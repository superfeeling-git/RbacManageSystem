using Rbac.IRepository;
using System;
using System.Collections.Generic;
using Rbac.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Rbac.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        protected RbacDbContext __db;

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            await __db.Set<TEntity>().AddAsync(entity);
            return await __db.SaveChangesAsync();
        }

        public virtual async Task<int> CreateAsync(IEnumerable<TEntity> entitys)
        {
            await __db.Set<TEntity>().AddRangeAsync(entitys);
            return await __db.SaveChangesAsync();
        }

        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entitys)
        {
            await __db.Set<TEntity>().BulkInsertAsync(entitys);
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            __db.Entry<TEntity>(entity).State = EntityState.Deleted;
            return await __db.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(TKey key)
        {
            var endity = await __db.Set<TEntity>().FindAsync(key);
            __db.Set<TEntity>().Remove(endity);
            return await __db.SaveChangesAsync();
        }

        public virtual async Task SingleDeleteAsync(TEntity entity)
        {
            await __db.Set<TEntity>().SingleDeleteAsync(entity);
        }

        public virtual async Task BulkDeleteAsync(IEnumerable<TEntity> entities)
        {
            await __db.Set<TEntity>().BulkDeleteAsync(entities);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity,bool>> Condition)
        {
            await __db.Set<TEntity>().Where(Condition).DeleteAsync();
        }

        public virtual async Task<TEntity> FindAsync(TKey key)
        {
            return await __db.Set<TEntity>().FindAsync(key);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            if (Condition != null)
                return await __db.Set<TEntity>().FirstOrDefaultAsync(Condition);
            else
                return await __db.Set<TEntity>().FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var list = __db.Set<TEntity>().AsQueryable();
            if (Condition != null)
                list = list.Where(Condition);
            return await list.ToListAsync();
        }

        public virtual (int, List<TEntity>) PagedList(Expression<Func<TEntity,TKey>> orderBy, int PageIndex = 1,int PageSize = 10, Expression<Func<TEntity, bool>> Condition = null)
        {
            var list = __db.Set<TEntity>().AsQueryable();
            if(Condition != null)
            {
                list = list.Where(Condition);
            }
            var pagedata = list.OrderBy(orderBy).Page(PageIndex, PageSize).ToList();
            return (list.Count(), pagedata);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity,bool>> Condition = null)
        {
            var list = __db.Set<TEntity>().AsQueryable();
            if(Condition != null)
            {
                list = list.Where(Condition);
            }
            return list;
        }

        public virtual async Task<int> UpdateAsync(Expression<Func<TEntity,bool>> Condition,Expression<Func<TEntity,TEntity>> updateExpression)
        {
            return await __db.Set<TEntity>().Where(Condition).UpdateAsync(updateExpression);
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var query = __db.Set<TEntity>().AsQueryable();
            if(Condition != null)
            {
                query = query.Where(Condition);
            }
            return query.AnyAsync();
        }
    }
}
