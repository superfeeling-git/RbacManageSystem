using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IRepository
{
    public interface IAdminRepository : IBaseRepository<Admin, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        Task<int> RemoveRole(int adminId);
        /// <summary>
        /// ≈˙¡ø≤Â»Î
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<AdminRole> entitys);
    }
}