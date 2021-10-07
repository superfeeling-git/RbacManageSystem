using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Dtos.Role;
using Rbac.IService;
using Rbac.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private IRoleService<ListDto> service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="_service"></param>
        public RoleController(IRoleService<ListDto> _service)
        {
            this.service = _service;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(InsertDto dto)
        {
            await service.CreateAsync(dto);
            return Ok();
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindAsync(int id)
        {
            var model = await service.FindAsync<RoleDto>(id);
            return Ok(model);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            return new JsonResult(await service.ListAsync());
        }

        /// <summary>
        /// 分页，未实现
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PageList(int PageSize = 10,int PageIndex = 1)
        {
            return Ok();
        }

        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(InsertDto dto)
        {
            var count = await service.UpdateAsync(m => m.RoleId == dto.RoleId, m => new Role
            {
                RoleName = dto.RoleName
            });

            return Ok(count);
        }

        [HttpGet]
        public async Task<IActionResult> GetPermission(int id)
        {
            return new JsonResult(await service.GetPermission(id));
        }

        [HttpPost]
        public async Task<IActionResult> SetPermission(Permission permission)
        {
            await service.SetPermission(permission);
            return Ok();
        }
    }
}
