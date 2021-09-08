﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IRepositoty;
using Rbac.Repository;
using Rbac.IService;
using Rbac.Service;

namespace Rbac.WebAPI.Inject
{
    public static class Injection
    {
        public static void inject(this IServiceCollection services)
        {
            services.AddScoped<ISysMenuRepository, SysMenuRepository>();
            services.AddScoped<ISysMenuService<Dto.SysMenu.ListDto>, SysMenuService<Dto.SysMenu.ListDto>>();
        }
    }
}
