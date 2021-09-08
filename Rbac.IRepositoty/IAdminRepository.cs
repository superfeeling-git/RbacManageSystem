using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IRepositoty
{
    public interface IAdminRepository : IBaseRepository<Admin, int>
    {
    }
}
