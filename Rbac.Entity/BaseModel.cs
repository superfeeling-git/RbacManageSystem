using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rbac.Entity
{
    public class BaseModel<TKey>
    {
        public TKey CreateById { get; set; }
        [StringLength(50)]
        public string CreateByName { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
