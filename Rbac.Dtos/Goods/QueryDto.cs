using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Goods
{
    public class QueryDto
    {
        public int? CategoryId { get; set; }
        public string GoodsName { get; set; }
    }
}
