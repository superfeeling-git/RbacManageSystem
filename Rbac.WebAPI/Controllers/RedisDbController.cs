using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRedis;

namespace Rbac.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisDbController : ControllerBase
    {
        private CSRedisClient client;
        public RedisDbController()
        {
            //this.client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetVal()
        {
            return Ok(await RedisHelper.GetAsync("admin:1"));
        }
    }
}
