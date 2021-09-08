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
        public int RoleID { get; set; }
        ///<Summary>
        /// 角色名称
        ///</Summary>
        public string RoleName { get; set; }
        #endregion    
    }
}
