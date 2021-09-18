using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IService;
using Rbac.Dtos.SysMenu;
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

        [HttpPost]
        public async Task<IActionResult> CreateRootMenuAsync(InsertDto dto)
        {
            await sysMenuservice.CreateAsync(dto);
            return Ok();
        }

        [HttpGet]
        public IActionResult RootMenu()
        {
            return Ok(sysMenuservice.getRootMenu());
        }

        [HttpGet]
        public async Task<IActionResult> QueryMenu(int id)
        {
            return Ok(await sysMenuservice.FindAsync(id));
        }

        [HttpPost]
        public IActionResult QueryMenu(QueryDto dto)
        {
            return Ok(sysMenuservice.QueryMenu(dto));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await sysMenuservice.CreateAsync(new InsertDto { MenuName = "系统设置", ParnetID = 0, MenuLink = "http", IsShow = true });
            return Ok();
        }
    }
}
