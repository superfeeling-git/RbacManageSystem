using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Goods
{
    public class ListDto
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
        public int GoodsPrice { get; set; }
        public string GoodsPic { get; set; }
        public string CategoryName { get; set; }
    }
}
