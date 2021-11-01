using Rbac.Dtos.Role;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IService
{
    public interface IRoleService<TDto> : IBaseService<Role, TDto, int>
        where TDto : class, new()
    {
        Task<List<int>> GetPermission(int id);
        Task SetPermission(Permission permission);
        List<int> getRolesByMenu(string url);
    }
}
