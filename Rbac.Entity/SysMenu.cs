using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class SysMenu : BaseModel<int>
    {
        ///<Summary>
        /// 
        ///</Summary>
        public int MenuId { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuName { get; set; } = "空节点";
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuLink { get; set; } = "javascript:void(0)";
        ///<Summary>
        /// 
        ///</Summary>
        public bool IsShow { get; set; } = false;
        ///<Summary>
        /// 父节点ID
        ///</Summary>
        public int ParentId { get; set; } = 0;
        /// <summary>
        /// 菜单角色
        /// </summary>
        public List<RoleMenu> RoleMenu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }
    }
}
