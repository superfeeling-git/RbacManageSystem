using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IService;
using Rbac.Dto.SysMenu;

namespace Rbac.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class SysMenuController : Controller
    {
        private ISysMenuService<ListDto> sysMenuservice;

        public SysMenuController(ISysMenuService<ListDto> _sysMenuservice)
        {
            this.sysMenuservice = _sysMenuservice;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await sysMenuservice.CreateAsync(new InsertDto { MenuName = "系统设置", ParnetID = 0, MenuLink = "http", IsShow = true });
            return Ok();
        }
    }
}
