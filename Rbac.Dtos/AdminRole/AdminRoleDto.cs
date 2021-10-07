using Rbac.Dtos.Admin;
using Rbac.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.AdminRole
{
    public class AdminRoleDto : BaseDto
    {        
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int RoleId { get; set; } 
    }
}
