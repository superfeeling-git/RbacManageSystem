using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rbac.IRepositoty;
using Rbac.Unitity;

namespace Rbac.Service
{
    public class BaseService<TEntity, TDto, TKey> : IBaseService<TEntity, TDto, TKey>
        where TEntity : class, new()
        where TDto : class, new()
        where TKey : struct
    {
        protected IBaseRepository<TEntity, TKey> baseRepository;

        public async Task BulkDeleteAsync(IEnumerable<TDto> entities)
        {
            await baseRepository.BulkDeleteAsync(entities.MapToList<TDto, TEntity>());
        }

        public async Task BulkInsertAsync<TInsertDto>(IEnumerable<TInsertDto> entitys)
        {
            await baseRepository.BulkInsertAsync(entitys.MapToList<TInsertDto, TEntity>());
        }

        public async Task<int> CreateAsync<TInsertDto>(IEnumerable<TInsertDto> entitys)
        {
            return await baseRepository.CreateAsync(entitys.MapToList<TInsertDto, TEntity>());
        }

        public async Task<int> CreateAsync<TInsertDto>(TInsertDto entity)
        {
            return await baseRepository.CreateAsync(entity.MapTo<TEntity>());
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> Condition)
        {
            await baseRepository.DeleteAsync(Condition);
        }

        public async Task<int> DeleteAsync(TDto entity)
        {
            return await baseRepository.DeleteAsync(entity.MapTo<TEntity>());
        }

        public async Task<int> DeleteAsync(TKey key)
        {
            return await baseRepository.DeleteAsync(key);
        }

        public async Task<TDto> FindAsync(TKey key)
        {
            var entity = await baseRepository.FindAsync(key);
            return entity.MapTo<TDto>();
        }

        public async Task<TDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var entity = await baseRepository.FirstOrDefaultAsync(Condition);
            return entity.MapTo<TDto>();
        }

        public async Task<List<TDto>> ListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var entity = await baseRepository.ListAsync(Condition);
            return entity.MapToList<TEntity, TDto>();
        }

        public (int, List<TDto>) PagedList<TInsertDto>(Expression<Func<TEntity, TKey>> orderBy, int PageIndex = 1, int PageSize = 10, Expression<Func<TEntity, bool>> Condition = null)
        {
            var entity = baseRepository.PagedList(orderBy, PageIndex, PageSize, Condition);
            return (entity.Item1, entity.Item2.MapToList<TEntity, TDto>());
        }

        public async Task SingleDeleteAsync(TDto dto)
        {
            await baseRepository.SingleDeleteAsync(dto.MapTo<TEntity>());
        }

        public void UpdateAsync<TUpdateDto>(Expression<Func<TUpdateDto, bool>> Condition, Expression<Func<TUpdateDto, TUpdateDto>> updateExpression)
        {
            baseRepository.UpdateAsync(Condition.MapTo<Expression<Func<TEntity, bool>>>(), Condition.MapTo<Expression<Func<TEntity, TEntity>>>());
        }
    }
}
