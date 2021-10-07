using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.Dtos.SysMenu;
using Rbac.Dtos;

namespace Rbac.IService
{
    public interface ISysMenuService<TDto> : IBaseService<SysMenu, TDto, int>
        where TDto : class, new()
    {
        List<RootMenuDto> getRootMenu();
        List<MenuDto> QueryMenu(QueryDto dto);
        new Task<ResultInfo> DeleteAsync(int key);
        /// <summary>
        /// 获取递归菜单
        /// </summary>
        /// <returns></returns>
        List<ListDto> GetMenu();
        /// <summary>
        /// 获取递归节点
        /// </summary>
        /// <returns></returns>
        List<TreeDto> GetNodes();
        /// <summary>
        /// 根据ID获取路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> GetPath(int id);
    }
}
