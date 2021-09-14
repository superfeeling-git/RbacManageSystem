using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.SysMenu
{
    public class RootMenuDto : BaseDto
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
    }
}
