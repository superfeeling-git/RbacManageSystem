using Rbac.Dtos;
using Rbac.Dtos.Admin;
using Rbac.Entity;
using Rbac.IRepositoty;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rbac.Unitity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Rbac.Service
{
    public class AdminService<TDto> : BaseService<Admin, TDto, int>, IAdminService<TDto>
        where TDto : class, new()
    {
        private IAdminRepository adminRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IConfiguration configuration;


        public AdminService(
            IAdminRepository adminRepository, 
            IHttpContextAccessor _httpContextAccessor,
            IConfiguration _configuration
            )
        {
            this.baseRepository = adminRepository;
            this.adminRepository = adminRepository;
            this.httpContextAccessor = _httpContextAccessor;
            this.configuration = _configuration;
        }

        public async Task<JwtDto> Login(LoginDto loginDto)
        {
            var code = httpContextAccessor.HttpContext.Request.Cookies["SetCode"];
            if(loginDto.ValidateCode.ToLower() != code.ToLower())
            {
                return new JwtDto { code = 1, msg = "验证码错误" };
            }

            var admin = await adminRepository.FirstOrDefaultAsync(m => m.UserName == loginDto.UserName);
            if(admin == null)
            {
                return new JwtDto { code = 1, msg = "用户不存在" };
            }
            else
            {
                if(MD5Helper.Encrypt(loginDto.Password).ToLower() != admin.Password.ToLower())
                {
                    return new JwtDto { code = 1, msg = "密码错误" };
                }
                else
                {
                    IList<Claim> claims = new List<Claim> {
                        new Claim(JwtClaimTypes.JwtId,loginDto.UserName),
                        new Claim(JwtClaimTypes.Name,loginDto.UserName),
                        new Claim(JwtClaimTypes.Role,string.Join(",", ""))
                    };

                    //JWT密钥
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Bearer:SecurityKey"]));

                    //算法
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //过期时间
                    DateTime expires = DateTime.UtcNow.AddMinutes(10);


                    //Payload负载
                    var token = new JwtSecurityToken(
                        issuer: configuration["JwtConfig:Bearer:Issuer"],
                        audience: configuration["JwtConfig:Bearer:Audience"],
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: expires,
                        signingCredentials: cred
                        );

                    var handler = new JwtSecurityTokenHandler();

                    //生成令牌
                    string jwt = handler.WriteToken(token);

                    return new JwtDto { code = 0, token = jwt, expires = expires };
                }
            }
        }
    }
}
