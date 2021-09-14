using Rbac.Dtos.Goods;
using Rbac.Entity;
using Rbac.IRepository;
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

        public List<ListDto> JoinList()
        {
            var list = _db.GoodsCategory.Join
                (_db.Goods, a => a.CategoryId, b => b.CategoryId, 
                (a, b) => new ListDto { });
            return list.ToList();
        }
    }
}
