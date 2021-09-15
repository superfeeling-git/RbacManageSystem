using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.IService;
using Rbac.IRepository;
using Rbac.Dtos.SysMenu;
using Rbac.Unitity;

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

        public List<TDto> QueryMenu(QueryDto dto)
        {
            var list = sysMenuRepository.Query();
            if (!string.IsNullOrWhiteSpace(dto.MenuName))
            {
                list = list.Where(m => m.MenuName.Contains(dto.MenuName));
            }

            return list.ToList().MapToList<SysMenu, TDto>();
        }
    }
}
