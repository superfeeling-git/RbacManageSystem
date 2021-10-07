using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Dtos.Role;

namespace Rbac.Dtos.Admin
{
    public class SettingRolesDto
    {
        public int AdminId { get; set; }
        public List<RoleDto> Role { get; set; }
    }
}
