using Rbac.Dtos.Role;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IRepository
{
    public interface IRoleRepository : IBaseRepository<Role, int>
    {
        Task<List<int>> GetPermission(int id);
        Task SetPermission(Permission permission);
    }
}