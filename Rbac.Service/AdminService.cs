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
using Rbac.Dtos.Role;
using Rbac.Dtos;
using AutoMapper;
using System.Linq.Expressions;


namespace Rbac.Service
{
    public class AdminService<TDto> : BaseService<Admin, TDto, int>, IAdminService<TDto>
        where TDto : class, new()
    {
        private IAdminRepository adminRepository;
        private IRoleRepository roleRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IConfiguration configuration;
        private IMapper mapper;

        public AdminService
            (
            IAdminRepository adminRepository,
            IHttpContextAccessor _httpContextAccessor,
            IConfiguration _configuration,
            IRoleRepository roleRepository,
            IMapper mapper
            )
        {
            this.baseRepository = adminRepository;
            this.adminRepository = adminRepository;
            this.httpContextAccessor = _httpContextAccessor;
            this._httpContextAccessor = _httpContextAccessor;
            this.configuration = _configuration;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        public async Task<JwtDto> Login(LoginDto loginDto)
        {
            var code = httpContextAccessor.HttpContext.Request.Cookies["SetCode"];

            var inputcode = MD5Helper.Encrypt($"{loginDto.ValidateCode.ToLower()}{configuration["JwtConfig:CookiesKey"]}");

            if (!string.IsNullOrWhiteSpace(code))
            {
                if (inputcode != code.ToLower() && loginDto.ValidateCode != "string")
                {
                    return new JwtDto { code = 1, msg = "验证码错误" };
                }
            }

            var admin = await adminRepository.FirstOrDefaultAsync(m => m.UserName == loginDto.UserName);
            if (admin == null)
            {
                return new JwtDto { code = 1, msg = "用户不存在" };
            }
            else
            {
                if (MD5Helper.Encrypt(loginDto.Password).ToLower() != admin.Password.ToLower())
                {
                    return new JwtDto { code = 1, msg = "密码错误" };
                }
                else
                {
                    //更新末次登录时间
                    await adminRepository.UpdateAsync(m => m.UserName == admin.UserName, m => new Admin { LastLoginTime = DateTime.Now });

                    var roles = string.Join(",",await adminRepository.GetRoleAsync(admin.AdminId));

                    IList<Claim> claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Id,admin.AdminId.ToString()),
                        new Claim(JwtClaimTypes.Name,loginDto.UserName),
                        new Claim(JwtClaimTypes.Email,loginDto.UserName),
                        new Claim(JwtClaimTypes.Role,roles)

                    };

                    //JWT密钥
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Bearer:SecurityKey"]));

                    //算法
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //过期时间
                    DateTime expires = DateTime.UtcNow.AddHours(10);


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

        /// <summary>
        /// 配置角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task SettingRoles(SettingRolesDto dto)
        {
            await roleRepository.BulkInsertAsync(dto.Role.MapToList<RoleDto, Role>());
        }

        public async Task<ResultInfo> CreateAsync(AdminDto dto)
        {
            if (await adminRepository.ExistsAsync(m => m.UserName == dto.UserName))
            {
                return new ResultInfo { code = 1, msg = "已经存在同名管理员" };
            }

            dto.Password = MD5Helper.Encrypt(dto.Password);

            var admin = mapper.Map<AdminDto, Admin>(dto);

            await adminRepository.CreateAsync(admin);

            return new ResultInfo { code = 0 };
        }

        public (int, List<TDto>) PagedList(Expression<Func<Admin, int>> orderBy, int PageIndex = 1, int PageSize = 10, string keywords = "")
        {
            var list = adminRepository.Query();
            if(!string.IsNullOrWhiteSpace(keywords))
            {
                list = list.Where(m=>m.UserName.Contains(keywords));
            }

            return list.OrderBy(orderBy).PagedList<Admin,TDto>(PageIndex, PageSize);
        }


        public override async Task<AdminDto> FindAsync<AdminDto>(int key)
        {
            var admin = await adminRepository.FindAsync(key);
            admin.Password = string.Empty;
            return mapper.Map<Admin, AdminDto>(admin);
        }

        public async Task<ResultInfo> UpdateAsync(AdminDto dto)
        {
            if (await adminRepository.ExistsAsync(m => m.UserName == dto.UserName && m.AdminId != dto.AdminId))
            {
                return new ResultInfo { code = 1, msg = "已经存在同名管理员" };
            }

            var admin = mapper.Map<AdminDto, Admin>(dto);            

            await adminRepository.RemoveRoleAsync(dto.AdminId);

            await adminRepository.BulkInsertAsync(admin.AdminRole);

            if(!string.IsNullOrWhiteSpace(admin.Password))
            {
                dto.Password = MD5Helper.Encrypt(dto.Password);

                await adminRepository.UpdateAsync(m => m.AdminId == dto.AdminId, admin => new Admin
                {
                    UserName = dto.UserName,
                    Password = dto.Password
                });
            }
            else
            {
                await adminRepository.UpdateAsync(m => m.AdminId == dto.AdminId, admin => new Admin
                {
                    UserName = dto.UserName
                });
            }            

            return new ResultInfo { code = 0 };
        }
    }
}
