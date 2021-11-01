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
    //[Authorize]
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
        public async Task<IActionResult> CreateMenuAsync(InsertDto dto)
        {
            await sysMenuservice.CreateAsync(dto);
            return Ok();
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
        /// 获取递归结构的菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuAsync()
        {
            var list = sysMenuservice.GetMenu();
            return new JsonResult(list);
        }

        /// <summary>
        /// 获取递归结构的菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNodeAsync()
        {
            return new JsonResult(sysMenuservice.GetNodes());
        }

        /// <summary>
        /// 更新菜单名称
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateMenu(MenuDto dto)
        {
            var count = await sysMenuservice.UpdateAsync(m => m.MenuId == dto.MenuID, m => 
            new SysMenu {
                MenuName = dto.MenuName,
                IsShow = dto.IsShow,
                MenuLink = dto.MenuLink,
                ParentId = dto.ParentID,
                OrderId = dto.OrderId
            });
            return Ok(count);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await sysMenuservice.DeleteAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPath(int id)
        {
            return new JsonResult(sysMenuservice.GetPath(id));
        }


        [HttpGet]
        public IActionResult GetLoginInfoAsync()
        {
            return new JsonResult(HttpContext.User.Claims);
        }
    }
}
