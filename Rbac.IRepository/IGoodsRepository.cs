using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Dtos.Goods;

namespace Rbac.IRepository
{
    public interface IGoodsRepository : IBaseRepository<Goods, int>
    {
        List<ListDto> JoinList();
    }
}
