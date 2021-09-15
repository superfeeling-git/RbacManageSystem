using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Dtos.Customer;
using Microsoft.AspNetCore.Http;

namespace Rbac.Service
{
    public class CustomerService<TDto> : BaseService<Customer, TDto, int>, ICustomerService<TDto>
        where TDto : class, new()
    {
        private ICustomerRepository repository;

        public CustomerService(ICustomerRepository _repository, IHttpContextAccessor _httpContextAccessor)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this._httpContextAccessor = _httpContextAccessor;
        }

        public override Task<int> CreateAsync<TInsertDto>(TInsertDto entity)
        {
            if(entity is InsertDto dto)
            {
                dto.CustomerCode = DateTime.Now.ToString("yyyyMMddmmHHss");
            }

            return base.CreateAsync(entity);
        }
    }
}
