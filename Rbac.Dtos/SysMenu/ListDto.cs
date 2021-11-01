using System;
using System.Collections.Generic;

namespace Rbac.Dtos.SysMenu
{
    public class ListDto : BaseDto
    {
        ///<Summary>
        /// 
        ///</Summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 
        /// </summary>
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
        public int ParentId { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public List<ListDto> children { get; set; } = new List<ListDto>();
    }
}
