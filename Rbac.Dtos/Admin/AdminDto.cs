﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Rbac.Dtos.AdminRole;
using Rbac.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos.Admin
{
    public class AdminDto : BaseDto
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<AdminRoleDto> AdminRole { get; set; }
    }
}
