using System;
using System.Collections.Generic;

namespace Rbac.Dtos.SysMenu
{
    public class ListDto
    {
        ///<Summary>
        /// 
        ///</Summary>
        public int MenuID { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuName { get; set; }
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
