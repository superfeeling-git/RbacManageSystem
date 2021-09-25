using Rbac.Dtos;
using Rbac.Dtos.Goods;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IService
{
    public interface IGoodsService<TDto> : IBaseService<Goods, TDto, int>
        where TDto : class, new()
    {
        /// <summary>
        /// 带有条件查询的两条联查的商品分页
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        (int, List<ListDto>) PagedList(Expression<Func<ListDto, int>> orderBy, int PageIndex = 1, int PageSize = 10, QueryDto query = null);
    }
}
