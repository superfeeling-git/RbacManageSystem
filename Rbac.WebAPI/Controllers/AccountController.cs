using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Drawing.Drawing2D;
using System.Text;
using Rbac.IService;
using Rbac.Unitity;
using Rbac.Dtos.Admin;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private IConfiguration configuration;
        private ValidateCode validateCode;
        private IAdminService<ListDto> adminService;

        public AccountController(
            IConfiguration _configuration, 
            ValidateCode _validateCode,
            IAdminService<ListDto> _adminService
            )
        {
            this.configuration = _configuration;
            this.validateCode = _validateCode;
            this.adminService = _adminService;
        }

        [HttpGet]
        public IActionResult ValidateCode()
        {
            return File(validateCode.GeneratorCode().ToArray(), "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            return Ok(await adminService.Login(login));
        }
    }
}
