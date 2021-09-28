using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Dtos.Student;
using Rbac.IService;
using Rbac.Entity;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService<ListDto> service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="_service"></param>
        public StudentController(IStudentService<ListDto> _service)
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
        public async Task<IActionResult> Find(int id)
        {
            var model = await service.FindAsync<InsertDto>(id);
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
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }

    }
}
