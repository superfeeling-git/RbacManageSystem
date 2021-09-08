using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class AdminRole : BaseModel<int>
    {
        public int Id { get; set; }
        public Admin Admin { get; set; }
        public Role Role { get; set; }
    }
}
