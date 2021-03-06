using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.IRepository;
using Rbac.Repository;
using Rbac.IService;
using Rbac.Service;
using Rbac.Unitity;

namespace Rbac.WebAPI.Configuration
{
    public static class DI
    {
        public static void AddIoc(this IServiceCollection services)
        {
            services.AddScoped<ValidateCode>();
            services.AddScoped<ISysMenuRepository, SysMenuRepository>();
            services.AddScoped<ISysMenuService<Dtos.SysMenu.ListDto>, SysMenuService<Dtos.SysMenu.ListDto>>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService<Dtos.Admin.ListDto>, AdminService<Dtos.Admin.ListDto>>();
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            services.AddScoped<IGoodsService<Dtos.Goods.ListDto>, GoodsService<Dtos.Goods.ListDto>>();            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService<Dtos.Customer.ListDto>, CustomerService<Dtos.Customer.ListDto>>();
            services.AddScoped<IGoodsCategoryRepository, GoodsCategoryRepository>();
            services.AddScoped<IGoodsCategoryService<Dtos.GoodsCategory.ListDto>, GoodsCategoryService<Dtos.GoodsCategory.ListDto>>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractService<Dtos.Contract.ListDto>, ContractService<Dtos.Contract.ListDto>>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService<Dtos.Department.ListDto>, DepartmentService<Dtos.Department.ListDto>>();
            services.AddScoped<IGoodsCategoryRepository, GoodsCategoryRepository>();
            services.AddScoped<IGoodsCategoryService<Dtos.GoodsCategory.ListDto>, GoodsCategoryService<Dtos.GoodsCategory.ListDto>>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService<Dtos.Student.ListDto>, StudentService<Dtos.Student.ListDto>>();
        }
    }
}
