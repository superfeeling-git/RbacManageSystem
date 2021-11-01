using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.SysMenu
{
    public class MenuDto
    {
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
        public int OrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsShow { get; set; } = false;
        ///<Summary>
        /// 
        ///</Summary>
        public int ParentID { get; set; } = 0;
    }
}
