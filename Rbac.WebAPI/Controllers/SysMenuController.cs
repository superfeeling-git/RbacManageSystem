using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IService;
using Rbac.Dtos.SysMenu;
using Rbac.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    [Authorize]
    public class SysMenuController : Controller
    {
        private ISysMenuService<ListDto> sysMenuservice;

        public SysMenuController(ISysMenuService<ListDto> _sysMenuservice)
        {
            this.sysMenuservice = _sysMenuservice;
        }

        /// <summary>
        /// 创建一级菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRootMenuAsync(InsertDto dto)
        {
            await sysMenuservice.CreateAsync(dto);
            return Ok();
        }

        /// <summary>
        /// 获取所有一级菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RootMenu()
        {
            return Ok(sysMenuservice.getRootMenu());
        }

        /// <summary>
        /// 根据ID查询菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> QueryMenuAsync(int id)
        {
            return Ok(await sysMenuservice.FindAsync<InsertDto>(id));
        }

        /// <summary>
        /// 条件查询菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult QueryMenu(QueryDto dto)
        {
            return Ok(sysMenuservice.QueryMenu(dto));
        }

        /// <summary>
        /// 更新菜单名称
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateMenu(MenuDto dto)
        {
            var count = await sysMenuservice.UpdateAsync(m => m.MenuID == dto.MenuID, m => new SysMenu { MenuName = dto.MenuName });
            return Ok(count);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await sysMenuservice.DeleteAsync(id));
        }
    }
}
