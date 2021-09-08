using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class RoleMenu : BaseModel<int>
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Role Role { get; set; }
        public SysMenu SysMenu { get; set; }
    }
}
