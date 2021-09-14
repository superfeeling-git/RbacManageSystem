using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class ContractRepository : BaseRepository<Contract, int>, IContractRepository
    {
        private RbacDbContext _db;

        public ContractRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }
    }
}
