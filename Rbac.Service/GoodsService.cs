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

        public GoodsService(IGoodsRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
        }
    }
}
