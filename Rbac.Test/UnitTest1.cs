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
using Rbac.Dtos.Admin;
using Rbac.Unitity;

namespace Rbac.Test
{
    public class UnitTest1
    {
        //private IAdminService<ListDto> service;
        private IAdminRepository repository;
        public UnitTest1()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<RbacDbContext>(opt => {
                opt.UseSqlServer("Data Source=.;Initial Catalog=RbacManageSystem;Integrated Security=True");
            });

            services.AddScoped<IAdminRepository, AdminRepository>();
            //services.AddScoped<IAdminService<ListDto>, AdminService<ListDto>>();

            var provider = services.BuildServiceProvider();

            //service = provider.GetService<IAdminService<ListDto>>();
            repository = provider.GetService<IAdminRepository>();
        }


        [Fact]
        public async Task Test1()
        {
            var admin = await repository.FirstOrDefaultAsync(m => m.AdminId > 0);
            
        }
    }
}
