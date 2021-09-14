using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Department
{
    public class UpdateDto
    {
        
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptManage { get; set; }
    
    }
}
