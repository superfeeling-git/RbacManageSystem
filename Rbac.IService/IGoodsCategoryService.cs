using Rbac.Dtos;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IService
{
    public interface IGoodsCategoryService<TDto> : IBaseService<GoodsCategory, TDto, int>
        where TDto : class, new()
    {
        Task<List<TreeDto>> GetNodesAsync();
    }
}
