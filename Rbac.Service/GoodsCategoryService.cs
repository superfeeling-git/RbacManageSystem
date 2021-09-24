using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Rbac.Service
{
    public class GoodsCategoryService<TDto> : BaseService<GoodsCategory, TDto, int>, IGoodsCategoryService<TDto>
        where TDto : class, new()
    {
        private IGoodsCategoryRepository repository;

        public GoodsCategoryService(IGoodsCategoryRepository _repository, IHttpContextAccessor _httpContextAccessor)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this._httpContextAccessor = _httpContextAccessor;
        }


        
        public override Task<List<TDto>> ListAsync(Expression<Func<GoodsCategory, bool>> Condition = null)
        {
            return base.ListAsync(Condition);
        }
    }
}
