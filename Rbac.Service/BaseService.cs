using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rbac.IRepository;
using Rbac.Unitity;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using IdentityModel;

namespace Rbac.Service
{
    public abstract class BaseService<TEntity, TDto, TKey> : IBaseService<TEntity, TDto, TKey>
        where TEntity : class, new()
        where TDto : class, new()
        where TKey : struct
    {
        protected IBaseRepository<TEntity, TKey> baseRepository;
        protected IHttpContextAccessor _httpContextAccessor;

        public virtual async Task BulkDeleteAsync(IEnumerable<TDto> dtos)
        {
            await baseRepository.BulkDeleteAsync(dtos.MapToList<TDto, TEntity>());
        }

        public virtual async Task BulkInsertAsync<TInsertDto>(IEnumerable<TInsertDto> dtos)
        {
            var userid = _httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == JwtClaimTypes.Id).Value;
            var username = _httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == JwtClaimTypes.Name).Value;

            List<TEntity> entities = new List<TEntity>();

            foreach (var item in dtos)
            {
                TEntity entity = item.MapTo<TEntity>();
                Type type = entity.GetType();
                type.GetProperty("CreateById").SetValue(entity, Convert.ToInt32(userid));
                type.GetProperty("CreateByName").SetValue(entity, username);
                entities.Add(entity);
            }

            await baseRepository.BulkInsertAsync(entities);
        }

        public virtual async Task<int> CreateAsync<TInsertDto>(IEnumerable<TInsertDto> dtos)
        {
            var userid = _httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == JwtClaimTypes.Id).Value;
            var username = _httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == JwtClaimTypes.Name).Value;

            List<TEntity> entities = new List<TEntity>();

            foreach (var item in dtos)
            {
                TEntity entity = item.MapTo<TEntity>();
                Type type = entity.GetType();
                type.GetProperty("CreateById").SetValue(entity, Convert.ToInt32(userid));
                type.GetProperty("CreateByName").SetValue(entity, username);
                entities.Add(entity);
            }

            return await baseRepository.CreateAsync(entities);
        }

        public virtual async Task<int> CreateAsync<TInsertDto>(TInsertDto dto)
        {
            var userid = _httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == JwtClaimTypes.Id).Value;
            var username = _httpContextAccessor.HttpContext.User.Claims.First(m => m.Type == JwtClaimTypes.Name).Value;
            TEntity entity = dto.MapTo<TEntity>();
            Type type = entity.GetType();
            type.GetProperty("CreateById").SetValue(entity, Convert.ToInt32(userid));
            type.GetProperty("CreateByName").SetValue(entity, username);
            return await baseRepository.CreateAsync(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> Condition)
        {
            await baseRepository.DeleteAsync(Condition);
        }

        public virtual async Task<int> DeleteAsync(TDto dto)
        {
            return await baseRepository.DeleteAsync(dto.MapTo<TEntity>());
        }

        public virtual async Task<int> DeleteAsync(TKey key)
        {
            return await baseRepository.DeleteAsync(key);
        }

        public virtual async Task<TDto> FindAsync(TKey key)
        {
            var entity = await baseRepository.FindAsync(key);
            return entity.MapTo<TDto>();
        }

        public virtual async Task<TDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var entity = await baseRepository.FirstOrDefaultAsync(Condition);
            return entity.MapTo<TDto>();
        }

        public virtual async Task<List<TDto>> ListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var entity = await baseRepository.ListAsync(Condition);
            return entity.MapToList<TEntity, TDto>();
        }

        public virtual (int, List<TDto>) PagedList(Expression<Func<TEntity, TKey>> orderBy, int PageIndex = 1, int PageSize = 10, Expression<Func<TEntity, bool>> Condition = null)
        {
            var entity = baseRepository.PagedList(orderBy, PageIndex, PageSize, Condition);
            return (entity.Item1, entity.Item2.MapToList<TEntity, TDto>());
        }

        public virtual async Task SingleDeleteAsync(TDto dto)
        {
            await baseRepository.SingleDeleteAsync(dto.MapTo<TEntity>());
        }

        public virtual async Task<int> UpdateAsync(Expression<Func<TEntity, bool>> Condition, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            return await baseRepository.UpdateAsync(Condition, updateExpression);
        }
    }
}
