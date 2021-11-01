using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IService;
using Rbac.IRepository;
using Rbac.Repository;
using Rbac.Entity;
using Rbac.Dtos.Role;
using Microsoft.AspNetCore.Http.Extensions;
using IdentityModel;
using System.Security.Claims;
using System.Text;

namespace Rbac.WebAPI
{
    public class AuthonizationFilter : Attribute, IAuthorizationFilter
    {
        private IRoleService<ListDto> service;

        public AuthonizationFilter(IRoleService<ListDto> service)
        {
            this.service = service;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var action = (ControllerActionDescriptor)context.ActionDescriptor;

            if(action.ControllerName.ToLower() != "account")
            {
                if (!context.HttpContext.User.Identity.IsAuthenticated)
                {
                    context.HttpContext.Response.StatusCode = 405;
                    context.HttpContext.Response.Headers.Add("拒绝访问", "权限不足");
                }
                else
                {
                    var url = $"/{action.ControllerName}/{action.ActionName}";
                    List<int> roleid = service.getRolesByMenu(url);
                    var claims = context.HttpContext.User.Claims;
                    var currRole = context.HttpContext.User.Claims.First(m => m.Type == ClaimTypes.Role).Value.Split(',').Select(m => Convert.ToInt32(m));
                    if (!currRole.Any(m => roleid.Contains(m)))
                    {
                        /*//响应状态码
                        context.HttpContext.Response.StatusCode = 405;
                        //添加响应头
                        context.HttpContext.Response.Headers.Add("no-access", "no-permission");
                        //输出响应消息
                        string text = "output string";
                        byte[] bytes = Encoding.UTF8.GetBytes(text);                        
                        context.HttpContext.Response.Body.WriteAsync(bytes);
                        //终止输出
                        context.HttpContext.Response.CompleteAsync(); */                       
                    }
                }
            }
        }
    }
}
