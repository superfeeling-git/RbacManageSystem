using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class AdminRepository : BaseRepository<Admin, int>, IAdminRepository
    {
        private RbacDbContext _db;

        public AdminRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }

        public void Test()
        {
            var a = _db.Admin.AsQueryable();
            var b = _db.Customer.AsQueryable();

            var c = a.Join(b, a => a.AdminId, b => b.CreateId,(a,b)=> new { a, b });

            foreach (var item in c)
            {
                
            }
        }
    }
}
