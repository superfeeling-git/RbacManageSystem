using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Admin
{
    public class InsertDto
    {
        
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }    
    }
}
