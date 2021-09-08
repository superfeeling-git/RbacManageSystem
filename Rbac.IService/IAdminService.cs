using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Dtos.Admin;
using Rbac.Dtos;

namespace Rbac.IService
{
    public interface IAdminService<TDto> : IBaseService<Admin, TDto, int>
        where TDto : class, new()
    {
        Task<JwtDto> Login(LoginDto loginDto);
    }
}
