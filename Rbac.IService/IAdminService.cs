using Rbac.Dtos;
using Rbac.Dtos.Admin;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IService
{
    public interface IAdminService<TDto> : IBaseService<Admin, TDto, int>
        where TDto : class, new()
    {
        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        Task<JwtDto> Login(LoginDto loginDto);
        /// <summary>
        /// ���ý�ɫ
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task SettingRoles(SettingRolesDto dto);
        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <typeparam name="TInsertDto"></typeparam>
        /// <param name="dtos"></param>
        /// <returns></returns>
        Task<ResultInfo> CreateAsync(AdminDto dtos);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        (int, List<TDto>) PagedList(Expression<Func<Admin, int>> orderBy, int PageIndex = 1, int PageSize = 10, string keywords = "");
        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResultInfo> UpdateAsync(AdminDto dto);
    }
}
