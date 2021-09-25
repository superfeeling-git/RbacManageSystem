using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class Goods : BaseModel<int>
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
        public int GoodsPrice { get; set; }
        public string GoodsPic { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public GoodsCategory GoodsCategory { get; set; }
    }
}
