using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class Permission : BaseModel<int>
    {
        ///<Summary>
        /// 
        ///</Summary>
        public int PermissionId { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string PermissionName { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string PermissionLink { get; set; }
        ///<Summary>
        /// 父节点ID
        ///</Summary>
        public int ParentId { get; set; } = 0;
        /// <summary>
        /// 菜单角色
        /// </summary>
        public List<RolePermission> RolePermission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }
    }
}
