using Rbac.Entity;
using Rbac.IRepositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class GoodsRepository : BaseRepository<Goods, int>, IGoodsRepository
    {
        private RbacDbContext _db;

        public GoodsRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }
    }
}
