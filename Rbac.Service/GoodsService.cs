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

        public List<ListDto> GetAllGoods()
        {
            /*var goods = repository.Query();
            var category = categoryRepository.Query();

            var list = goods.Join(category, a => a.CategoryId, b => b.CategoryId,(a,b)=> new ListDto {
                CategoryName = b.CategoryName,
                GoodsID = a.GoodsID,
                GoodsName = a.GoodsName,
                GoodsPic = a.GoodsPic,
                GoodsPrice = a.GoodsPrice
            });*/

            //return list.ToList();

            return repository.JoinList();            
        }
    }
}
