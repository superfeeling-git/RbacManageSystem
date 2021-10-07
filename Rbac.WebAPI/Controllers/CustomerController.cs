using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Dtos.Customer;
using Rbac.IService;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "mom")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService<ListDto> service;

        public CustomerController(ICustomerService<ListDto> _service)
        {
            this.service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertDto dto)
        {
            var count = await service.CreateAsync(dto);
            return Ok(count);
        }
    }
}
