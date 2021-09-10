using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Create(Dtos.Admin.InsertDto insertDto)
        {
            return Ok();
        }
    }
}
