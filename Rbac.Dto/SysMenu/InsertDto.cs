using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dto.SysMenu
{
    public class InsertDto
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
    }
}
