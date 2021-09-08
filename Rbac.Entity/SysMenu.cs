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
        public string MenuLink { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public bool IsShow { get; set; } = false;
        ///<Summary>
        /// 
        ///</Summary>
        public int? ParnetID { get; set; }
        public List<RoleMenu> RoleMenu { get; set; }
    }
}
