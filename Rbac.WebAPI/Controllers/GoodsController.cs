using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Dtos.Goods;
using Rbac.IService;
using Rbac.Entity;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "gp")]
    public class GoodsController : ControllerBase
    {
        private IGoodsService<ListDto> service;
        private IGoodsCategoryService<Dtos.GoodsCategory.ListDto> categoryService;
        private IWebHostEnvironment env;



        public GoodsController(IGoodsService<ListDto> _service,
            IGoodsCategoryService<Dtos.GoodsCategory.ListDto> _categoryService,
            IWebHostEnvironment env
            )
        {
            this.categoryService = _categoryService;
            this.service = _service;
            this.env = env;
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
        public async Task<IActionResult> GetList()
        {
            return new JsonResult(await service.ListAsync());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="GoodsName"></param>
        /// <param name="CategoryId"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PageList(string GoodsName, int CategoryId = 0,int PageSize = 10,int PageIndex = 1)
        {
            return Ok(service.PagedList(m=>m.GoodsID,PageIndex,PageSize,new QueryDto { CategoryId = CategoryId, GoodsName = GoodsName }));
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
        public async Task<IActionResult> BulkDelete(List<ListDto> dtos)
        {
            await service.BulkDeleteAsync(dtos);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(InsertDto dto)
        {
            var count = await service.UpdateAsync(m => m.GoodsID == dto.GoodsId, m => new Goods {
                GoodsName = dto.GoodsName,
                GoodsPic = dto.GoodsPic,
                GoodsPrice = dto.GoodsPrice,
                Details = dto.Details,
                CategoryId = dto.CategoryId
            });

            return Ok(count);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPic(IFormFile file)
        {
            string fileName = string.Empty;

            if (file.Length > 0)
            {
                fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";

                string filePath = $"{env.WebRootPath}/Uploadfiles/{fileName}";

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return Ok(new { fileName = fileName });
        }
    }
}