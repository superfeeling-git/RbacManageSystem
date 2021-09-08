using System;
using Xunit;
using Rbac.IRepositoty;
using Rbac.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Rbac.Repository;
using Rbac.IService;
using Rbac.Service;
using Rbac.Dto.SysMenu;

namespace Rbac.Test
{
    public class UnitTest1
    {
        private ISysMenuService<Dto.SysMenu.ListDto> service;
        private ISysMenuRepository repository;
        public UnitTest1()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<RbacDbContext>(opt => {
                opt.UseSqlServer("Data Source=.;Initial Catalog=RbacManageSystem;Integrated Security=True");
            });

            services.AddScoped<ISysMenuRepository, SysMenuRepository>();
            services.AddScoped<ISysMenuService<Dto.SysMenu.ListDto>, SysMenuService<Dto.SysMenu.ListDto>>();

            var provider = services.BuildServiceProvider();

            service = provider.GetService<ISysMenuService<Dto.SysMenu.ListDto>>();
            repository = provider.GetService<ISysMenuRepository>();
        }


        [Fact]
        public async Task Test1()
        {
            
        }
    }
}
