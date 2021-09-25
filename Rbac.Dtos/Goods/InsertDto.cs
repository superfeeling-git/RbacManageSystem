using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Goods
{
    public class InsertDto
    {
        public int CategoryId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsPic { get; set; }
        public int GoodsPrice { get; set; }
        public string Details { get; set; }
    }
}
