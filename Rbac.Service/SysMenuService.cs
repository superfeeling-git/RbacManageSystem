using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.IService;
using Rbac.IRepository;
using Microsoft.AspNetCore.Http;
using Rbac.Unitity;
using Rbac.Dtos.SysMenu;
using Rbac.Dtos;
using Microsoft.Extensions.Logging;

namespace Rbac.Service
{
    public class SysMenuService<TDto> : BaseService<SysMenu, TDto, int> , ISysMenuService<TDto>
        where TDto : class, new()
    {
        private ISysMenuRepository sysMenuRepository;
        private Recurve reducer;
        private ILogger<SysMenuService<ListDto>> logger;
        private List<SysMenu> sysMenus;

        public SysMenuService(
            ISysMenuRepository sysMenuRepository, 
            IHttpContextAccessor _httpContextAccessor,
            ILogger<SysMenuService<ListDto>> logger,
            Recurve reducer
            )
        {
            this.baseRepository = sysMenuRepository;
            this.sysMenuRepository = sysMenuRepository;
            this._httpContextAccessor = _httpContextAccessor;
            this.logger = logger;
            this.reducer = reducer;
            this.sysMenus = sysMenuRepository.ListAsync().Result;
        }

        public List<RootMenuDto> getRootMenu()
        {
            return sysMenuRepository.Query().Where(m => m.ParentId == 0).MapToList<SysMenu, RootMenuDto>();
        }

        public List<MenuDto> QueryMenu(QueryDto dto)
        {
            var list = sysMenuRepository.Query();
            if (!string.IsNullOrWhiteSpace(dto.MenuName))
            {
                list = list.Where(m => m.MenuName.Contains(dto.MenuName));
            }
            return list.MapToList<SysMenu, MenuDto>();
        }

        private List<TreeDto> Nodes = new List<TreeDto>();

        public List<TreeDto> GetNodes()
        {
            List<CategoryDto> dtos = new List<CategoryDto>();

            foreach (var item in sysMenus)
            {
                dtos.Add(new CategoryDto { CategoryId = item.MenuId, CategoryName = item.MenuName, ParentId = item.ParentId });
            }

            foreach (var item in sysMenus.Where(m => m.ParentId == 0))
            {
                TreeDto treemodel = new TreeDto { value = item.MenuId, label = item.MenuName };
                reducer.GetSubNodes(treemodel, dtos);
                Nodes.Add(treemodel);
            }

            return Nodes;
        }


        private List<ListDto> Menus = new List<ListDto>();

        public List<ListDto> GetMenu()
        {
            foreach (var item in sysMenus.Where(m => m.ParentId == 0))
            {
                ListDto treemodel = item.MapTo<ListDto>();
                GetSubNodes(treemodel, sysMenus);
                Menus.Add(treemodel);
            }

            return Menus;
        }

        public void GetSubNodes(ListDto tree, List<SysMenu> list)
        {
            foreach (var item in list.Where(m => m.ParentId == tree.MenuId))
            {
                ListDto treemodel = item.MapTo<ListDto>();
                tree.children.Add(treemodel);
                GetSubNodes(treemodel, list);
            }
        }

        public async new Task<ResultInfo> DeleteAsync(int key)
        {
            if(await sysMenuRepository.FirstOrDefaultAsync(m => m.ParentId == key) != null)
            {
                return new ResultInfo { code = 1, msg = "还有子分类，不能删除" };
            }
            else
            {
                await base.DeleteAsync(key);
                return new ResultInfo { code = 0 };
            }
        }

        private List<int> Path = new List<int>();

        public List<int> GetPath(int id)
        {
            Path.Add(id);
            var list = GetParentPath(id).Where(m => m > 0).Reverse();
            return list.ToList();
        }

        /// <summary>
        /// 根据ID获取路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<int> GetParentPath(int id)
        {
            var menu = sysMenus.FirstOrDefault(m => m.MenuId == id);
            if(menu != null)
            {
                Path.Add(menu.ParentId);
                GetParentPath(menu.ParentId);
            }

            return Path;
        }
    }
}
