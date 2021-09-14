using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {

    }
}