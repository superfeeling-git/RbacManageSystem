using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.AdminRole
{
    public class UpdateDto
    {
        
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int RoleId { get; set; }
    
    }
}
