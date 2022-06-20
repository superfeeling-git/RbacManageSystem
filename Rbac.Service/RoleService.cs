using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rbac.Dtos.Role;

namespace Rbac.Service
{
    public class RoleService<TDto> : BaseService<Role, TDto, int>, IRoleService<TDto>
        where TDto : class, new()
    {
        private IRoleRepository repository;
        private ISysMenuRepository sysMenuRepository;

        public RoleService(IRoleRepository _repository, IHttpContextAccessor _httpContextAccessor, ISysMenuRepository sysMenuRepository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this.sysMenuRepository = sysMenuRepository;
            this._httpContextAccessor = _httpContextAccessor;
        }

        public async Task<List<int>> GetPermission(int id)
        {
            return await repository.GetPermission(id);
        }

        public async Task SetPermission(Permission permission)
        {
            await repository.SetPermission(permission);
        }

        public List<int> getRolesByMenu(string url)
        {
            return repository.getRolesByMenu(url);
        }
    }
}