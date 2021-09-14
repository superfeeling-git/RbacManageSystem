using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.Dtos.SysMenu;

namespace Rbac.IService
{
    public interface ISysMenuService<TDto> : IBaseService<SysMenu, TDto, int>
        where TDto : class, new()
    {
        List<RootMenuDto> getRootMenu();
    }
}
