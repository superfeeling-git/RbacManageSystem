using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Rbac.Dtos
{
    public class BaseDto
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string CreateByName { get; set; }

        public int CreateById { get; set; }
    }
}
