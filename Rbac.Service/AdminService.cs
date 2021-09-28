using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rbac.Dtos.Admin;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using Rbac.Unitity;
using Microsoft.Extensions.Configuration;

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

            var inputcode = MD5Helper.Encrypt($"{loginDto.ValidateCode.ToLower()}{configuration["JwtConfig:CookiesKey"]}");

            if (!string.IsNullOrWhiteSpace(code))
            {
                if (inputcode != code.ToLower() && loginDto.ValidateCode != "string")
                {
                    return new JwtDto { code = 1, msg = "��֤�����" };
                }
            }

            var admin = await adminRepository.FirstOrDefaultAsync(m => m.UserName == loginDto.UserName);
            if (admin == null)
            {
                return new JwtDto { code = 1, msg = "�û�������" };
            }
            else
            {
                if (MD5Helper.Encrypt(loginDto.Password).ToLower() != admin.Password.ToLower())
                {
                    return new JwtDto { code = 1, msg = "�������" };
                }
                else
                {
                    //дSession��Cookies����JWT


                    IList<Claim> claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Id,admin.AdminId.ToString()),
                        new Claim(JwtClaimTypes.Name,loginDto.UserName),
                        new Claim(JwtClaimTypes.Email,loginDto.UserName),
                        new Claim(JwtClaimTypes.Role,string.Join(",", ""))
                    };

                    //JWT��Կ
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Bearer:SecurityKey"]));

                    //�㷨
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //����ʱ��
                    DateTime expires = DateTime.UtcNow.AddHours(10);


                    //Payload����
                    var token = new JwtSecurityToken(
                        issuer: configuration["JwtConfig:Bearer:Issuer"],
                        audience: configuration["JwtConfig:Bearer:Audience"],
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: expires,
                        signingCredentials: cred
                        );

                    var handler = new JwtSecurityTokenHandler();

                    //��������
                    string jwt = handler.WriteToken(token);

                    return new JwtDto { code = 0, token = jwt, expires = expires };
                }
            }
        }
    }
}
