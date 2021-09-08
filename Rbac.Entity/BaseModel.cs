using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class BaseModel<TKey>
    {
        public TKey CreateId { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
