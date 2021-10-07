using Rbac.Dtos.AdminRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Role
{
    public class RoleDto : BaseDto
    {
        ///<Summary>
        /// 角色ID
        ///</Summary>
        public int RoleId { get; set; }
        ///<Summary>
        /// 角色名称
        ///</Summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AdminRoleDto> AdminRole { get; set; }
    }
}
