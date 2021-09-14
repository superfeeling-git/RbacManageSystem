using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class Department : BaseModel<int>
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptManage { get; set; }
    }
}
