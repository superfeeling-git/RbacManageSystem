using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        private RbacDbContext _db;

        public CustomerRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }
    }
}
