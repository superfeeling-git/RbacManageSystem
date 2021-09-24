using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class GoodsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ParnetID { get; set; } = 0;
        public List<Goods> Goods { get; set; }
    }
}
