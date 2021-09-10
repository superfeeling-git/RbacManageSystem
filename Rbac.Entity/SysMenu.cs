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
        public int MenuID { get; set; }
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
        public int ParnetID { get; set; } = 0;
        public List<RoleMenu> RoleMenu { get; set; }
    }
}
