using Microsoft.AspNetCore.Http;
using Rbac.Dtos.Goods;
using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Dtos;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Rbac.Unitity;

namespace Rbac.Service
{
    public class GoodsService<TDto> : BaseService<Goods, TDto, int>, IGoodsService<TDto>
        where TDto : class, new()
    {
        private IGoodsRepository repository;
        private IGoodsCategoryRepository categoryRepository;

        public GoodsService(
            IGoodsRepository _repository, 
            IGoodsCategoryRepository _categoryRepository,
            IHttpContextAccessor _httpContextAccessor
            )
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this.categoryRepository = _categoryRepository;
            this._httpContextAccessor = _httpContextAccessor;
        }

        /// <summary>
        /// 带有条件查询的两条联查的商品分页
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public (int, List<ListDto>) PagedList(Expression<Func<ListDto, int>> orderBy, int PageIndex = 1, int PageSize = 10, QueryDto query = null)
        {
            var goods = repository.Query();
            var categories = categoryRepository.Query();

            var list = goods.Join(categories, a => a.CategoryId, b => b.CategoryId, (a, b) => new ListDto {
                CategoryName = b.CategoryName,
                CreateByName = a.CreateByName,
                CreateTime = a.CreateTime,
                GoodsID = a.GoodsID,
                GoodsName = a.GoodsName,
                GoodsPic = a.GoodsPic,
                GoodsPrice = a.GoodsPrice,
                CategoryId = b.CategoryId
            });

            if(query.CategoryId != null && query.CategoryId > 0)
            {
                list = list.Where(m => m.CategoryId == query.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(query.GoodsName))
            {
                list = list.Where(m => m.GoodsName.Contains(query.GoodsName));
            }

            return (list.Count(), list.OrderBy(orderBy).Page(PageIndex, PageSize).ToList());
        }

        public async Task<EntityDto> FindAsync(int key)
        {
            //商品实体
            var model = (await repository.FindAsync(key)).MapTo<EntityDto>();
            //分类实体
            var category = await categoryRepository.FindAsync(model.CategoryId);

            var path = $"{category.ParentPath},{category.CategoryId}";

            var arr = path.Split(',').Select(m => Convert.ToInt32(m)).Where(m => m > 0).ToArray();

            model.value = arr;

            return model;
        }
    }
}
