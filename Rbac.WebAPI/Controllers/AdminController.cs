using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Dtos.Admin;
using Rbac.IService;
using Rbac.Entity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private IAdminService<ListDto> service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="_service"></param>
        public AdminController(IAdminService<ListDto> _service)
        {
            this.service = _service;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AdminDto dto)
        {
            return Ok(await service.CreateAsync(dto));
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var model = await service.FindAsync<AdminDto>(id);
            return Ok(model);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return new JsonResult(await service.ListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PageList(int PageSize = 10,int PageIndex = 1,string keywords="")
        {
            var list = service.PagedList(m => m.AdminId, PageIndex, PageSize, keywords);
            return Ok(list);
        }

        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SettingRolesAsync(SettingRolesDto dto)
        {
            await service.SettingRoles(dto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(AdminDto dto)
        {
            await service.UpdateAsync(dto);
            return Ok();
        }
    }
}
