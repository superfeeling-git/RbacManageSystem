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
    public class GoodsCategoryService<TDto> : BaseService<GoodsCategory, TDto, int>, IGoodsCategoryService<TDto>
        where TDto : class, new()
    {
        private IGoodsCategoryRepository repository;

        public GoodsCategoryService(IGoodsCategoryRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
        }
    }
}
