using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Rbac.IService;
using Rbac.Dtos.Department;
using Microsoft.Extensions.DependencyInjection;
using Rbac.IRepository;
using Rbac.Repository;
using Rbac.Service;
using Rbac.Entity;
using Microsoft.EntityFrameworkCore;

namespace Rbac.MsgService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //手动创建ServiceCollection
            IServiceCollection services_coll = new ServiceCollection();

            //配置容器注册
            services_coll.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services_coll.AddScoped<IDepartmentService<ListDto>, DepartmentService<ListDto>>();

            //EF Core的db上下文
            services_coll.AddDbContext<RbacDbContext>(option => {
                option.UseSqlServer("Data Source=LAPTOP-MCJ4ST99;Initial Catalog=RbacManageSystem;User ID=sa;password=lp_lucky");
            });

            services_coll.AddHttpContextAccessor();

            //GetService方法获取服务
            IServiceProvider provider = services_coll.BuildServiceProvider();

            var service = provider.GetService<IDepartmentService<ListDto>>();

            using (StreamWriter writer = new StreamWriter(@"E:\Teaching\RbacManageSystem\Rbac.MsgService\db.txt", true))
            {
                var list = await service.ListAsync();
                foreach (var item in list)
                {
                    writer.WriteLine(item.DeptName);
                }
            }
        }
    }
}
