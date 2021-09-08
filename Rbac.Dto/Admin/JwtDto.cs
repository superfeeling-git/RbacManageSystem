using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Admin
{
    public class JwtDto : ResultInfo
    {
        public string token { get; set; }
        public DateTime expires { get; set; }
    }
}
