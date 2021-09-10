using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IService
{
    public interface IGoodsService<TDto> : IBaseService<Goods, TDto, int>
        where TDto : class, new()
    {
    }
}
