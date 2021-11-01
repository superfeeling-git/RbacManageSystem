using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class Role : BaseModel<int>
    {
        #region 公共属性
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
        public List<AdminRole> AdminRole { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RolePermission> RolePermission { get; set; }
        #endregion    
    }
}
