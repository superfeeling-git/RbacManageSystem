using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rbac.Repository
{
    public class GoodsCategoryRepository : BaseRepository<GoodsCategory, int>, IGoodsCategoryRepository
    {
        private RbacDbContext _db;

        public GoodsCategoryRepository(RbacDbContext db)
        {
            this.__db = db;
            this._db = db;
        }
    }
}
