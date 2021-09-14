using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Service
{
    public class DepartmentService<TDto> : BaseService<Department, TDto, int>, IDepartmentService<TDto>
        where TDto : class, new()
    {
        private IDepartmentRepository repository;

        public DepartmentService(IDepartmentRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
        }
    }
}
