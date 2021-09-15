using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.SysMenu
{
    public class QueryDto
    {
        public string MenuName { get; set; }
        public int? ParentId { get; set; }
    }

}
