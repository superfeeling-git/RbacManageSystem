using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Dtos.Customer;

namespace Rbac.Service
{
    public class CustomerService<TDto> : BaseService<Customer, TDto, int>, ICustomerService<TDto>
        where TDto : class, new()
    {
        private ICustomerRepository repository;

        public CustomerService(ICustomerRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
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
