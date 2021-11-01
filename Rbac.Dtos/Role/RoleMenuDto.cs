using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Role
{
    public class RoleMenuDto
    {
        public int RoleId { get; set; }
        public List<int> MenuId { get; set; }
    }
}
