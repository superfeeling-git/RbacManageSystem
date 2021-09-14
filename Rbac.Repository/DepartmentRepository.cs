using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class DepartmentRepository : BaseRepository<Department, int>, IDepartmentRepository
    {
        private RbacDbContext _db;

        public DepartmentRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }
    }
}
