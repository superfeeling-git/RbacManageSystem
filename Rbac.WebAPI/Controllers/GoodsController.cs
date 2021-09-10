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
    public class GoodsController : ControllerBase
    {
        private IGoodsService<ListDto> service;

        public GoodsController(IGoodsService<ListDto> _service)
        {
            this.service = _service;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(InsertDto dto)
        {
            await service.CreateAsync(dto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> BulkInsertAsync(IEnumerable<InsertDto> dtos)
        {
            await service.BulkInsertAsync(dtos);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return new JsonResult(await service.ListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
