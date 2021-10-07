using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class AdminRole : BaseModel<int>
    {
        public virtual int Id { get; set; }
        public virtual int AdminId { get; set; }
        public virtual int RoleId { get; set; }
    }
}
