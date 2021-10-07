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

        public string CreateByName { get; set; } = HttpContext.Current.User.Claims.First(m => m.Type == JwtClaimTypes.Name).Value;

        public int CreateById { get; set; } = Convert.ToInt32(HttpContext.Current.User.Claims.First(m => m.Type == JwtClaimTypes.Id).Value);
    }
}
