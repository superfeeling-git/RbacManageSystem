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
using Rbac.Dtos;
using Rbac.Unitity;

namespace Rbac.Service
{
    public class GoodsCategoryService<TDto> : BaseService<GoodsCategory, TDto, int>, IGoodsCategoryService<TDto>
        where TDto : class, new()
    {
        private IGoodsCategoryRepository repository;
        private Recurve reducer;

        public GoodsCategoryService(
            IGoodsCategoryRepository _repository, 
            IHttpContextAccessor _httpContextAccessor,
            Recurve reducer
            )
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this._httpContextAccessor = _httpContextAccessor;
            this.reducer = reducer;
        }
        
        public override Task<List<TDto>> ListAsync(Expression<Func<GoodsCategory, bool>> Condition = null)
        {
            return base.ListAsync(Condition);
        }


        private List<TreeDto> Nodes = new List<TreeDto>();

        public async Task<List<TreeDto>> GetNodesAsync()
        {
            var List = (await repository.ListAsync()).MapToList<GoodsCategory,CategoryDto>();

            foreach (var item in List.Where(m => m.ParentId == 0))
            {
                TreeDto treemodel = new TreeDto { value = item.CategoryId, label = item.CategoryName };
                reducer.GetSubNodes(treemodel, List);
                Nodes.Add(treemodel);
            }

            return Nodes;
        }
    }
}
