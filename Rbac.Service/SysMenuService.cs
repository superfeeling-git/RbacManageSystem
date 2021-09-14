using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.IService;
using Rbac.IRepository;
using Microsoft.AspNetCore.Http;
using Rbac.Unitity;
using Rbac.Dtos.SysMenu;

namespace Rbac.Service
{
    public class SysMenuService<TDto> : BaseService<SysMenu, TDto, int> , ISysMenuService<TDto>
        where TDto : class, new()
    {
        private ISysMenuRepository sysMenuRepository;

        public SysMenuService(ISysMenuRepository sysMenuRepository, IHttpContextAccessor _httpContextAccessor)
        {
            this.baseRepository = sysMenuRepository;
            this.sysMenuRepository = sysMenuRepository;
            this._httpContextAccessor = _httpContextAccessor;
        }

        public List<RootMenuDto> getRootMenu()
        {
            return sysMenuRepository.Query().Where(m => m.ParnetID == 0).MapToList<SysMenu, RootMenuDto>();
        }
    }
}
