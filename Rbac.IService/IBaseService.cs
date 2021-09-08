using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rbac.IService
{
    public interface IBaseService<TEntity, TDto, TKey>
        where TEntity : class, new()
        where TDto : class, new()
        where TKey : struct
    {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task BulkDeleteAsync(IEnumerable<TDto> entities);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="TInsertDto"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task BulkInsertAsync<TInsertDto>(IEnumerable<TInsertDto> entitys);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="TInsertDto"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<int> CreateAsync<TInsertDto>(IEnumerable<TInsertDto> entitys);
        /// <summary>
        /// 单条插入
        /// </summary>
        /// <typeparam name="TInsertDto"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync<TInsertDto>(TInsertDto entity);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> Condition);
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TDto entity);
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TKey key);
        /// <summary>
        /// 根据主键返回单条实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TDto> FindAsync(TKey key);
        /// <summary>
        /// 根据条件返回单条实体
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        Task<TDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 根据条件返回集合
        /// </summary>
        /// <typeparam name="TInsertDto"></typeparam>
        /// <param name="Condition"></param>
        /// <returns></returns>
        Task<List<TDto>> ListAsync(Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 根据条件返回分页数据
        /// </summary>
        /// <typeparam name="TInsertDto"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        (int, List<TDto>) PagedList<TInsertDto>(Expression<Func<TEntity, TKey>> orderBy, int PageIndex = 1, int PageSize = 10, Expression<Func<TEntity, bool>> Condition = null);
        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task SingleDeleteAsync(TDto dto);
        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <typeparam name="TUpdateDto"></typeparam>
        /// <param name="Condition"></param>
        /// <param name="updateExpression"></param>
        void UpdateAsync<TUpdateDto>(Expression<Func<TUpdateDto, bool>> Condition, Expression<Func<TUpdateDto, TUpdateDto>> updateExpression);

    }
}
