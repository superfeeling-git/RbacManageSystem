using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IRepositoty;
using Rbac.Repository;
using Rbac.IService;
using Rbac.Service;
using Rbac.Unitity;

namespace Rbac.WebAPI.Inject
{
    public static class Injection
    {
        public static void inject(this IServiceCollection services)
        {
            services.AddScoped<ISysMenuRepository, SysMenuRepository>();
            services.AddScoped<ISysMenuService<Dtos.SysMenu.ListDto>, SysMenuService<Dtos.SysMenu.ListDto>>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService<Dtos.Admin.ListDto>, AdminService<Dtos.Admin.ListDto>>();
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            services.AddScoped<IGoodsService<Dtos.Goods.ListDto>, GoodsService<Dtos.Goods.ListDto>>();
            services.AddScoped<ValidateCode>();
        }
    }
}
