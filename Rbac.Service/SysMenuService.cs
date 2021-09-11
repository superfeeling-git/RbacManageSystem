using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.IService;
using Rbac.IRepository;

namespace Rbac.Service
{
    public class SysMenuService<TDto> : BaseService<SysMenu, TDto, int> , ISysMenuService<TDto>
        where TDto : class, new()
    {
        private ISysMenuRepository sysMenuRepository;

        public SysMenuService(ISysMenuRepository sysMenuRepository)
        {
            this.baseRepository = sysMenuRepository;
            this.sysMenuRepository = sysMenuRepository;
        }
    }
}
