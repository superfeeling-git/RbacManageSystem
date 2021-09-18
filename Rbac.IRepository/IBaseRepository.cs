using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rbac.IRepository
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
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<int> CreateAsync(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 单条添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(TEntity entity);
        /// <summary>
        /// 基于条件删除
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> Condition);
        /// <summary>
        /// 基于实体删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TEntity entity);
        /// <summary>
        /// 基于主键删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TKey key);
        /// <summary>
        /// 根据主键查找
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(TKey key);
        /// <summary>
        /// 根据条件（拉姆达）查找单条
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 获取实体列表（条件可空 m=>m.id==1）
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 获取可查询结果
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="orderBy">排序字段</param>
        /// <param name="PageIndex">默认1</param>
        /// <param name="PageSize">默认10</param>
        /// <param name="Condition">查询条件</param>
        /// <returns></returns>
        (int, List<TEntity>) PagedList(Expression<Func<TEntity, TKey>> orderBy, int PageIndex = 1, int PageSize = 10, Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task SingleDeleteAsync(TEntity entity);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="updateExpression"></param>
        Task<int> UpdateAsync(Expression<Func<TEntity, bool>> Condition, Expression<Func<TEntity, TEntity>> updateExpression);
    }
}
