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
        Task<int> RemoveRoleAsync(int adminId);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<AdminRole> entitys);
        /// <summary>
        /// 按角色获取
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        Task<List<int>> GetRoleAsync(int adminId);
    }
}