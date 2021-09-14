using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class Contract : BaseModel<int>
    {
        public int ContractId { get; set; }
        public string ContractName { get; set; }
        public double ContractMoney { get; set; }
        public int Square { get; set; }
        public DateTime SignDate { get; set; }
    }
}
