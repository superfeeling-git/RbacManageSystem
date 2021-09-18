using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Dtos.Goods;
using Rbac.IService;
using Rbac.Entity;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "gp")]
    public class GoodsController : ControllerBase
    {
        private IGoodsService<ListDto> service;
        private IGoodsCategoryService<Dtos.GoodsCategory.ListDto> categoryService;

        
        public GoodsController(IGoodsService<ListDto> _service
            , IGoodsCategoryService<Dtos.GoodsCategory.ListDto> _categoryService
            )
        {
            this.categoryService = _categoryService;
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
            var model = await service.FindAsync(id);
            return Ok(model);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            return new JsonResult(service.GetAllGoods());
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