using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Rbac.Service
{
    public class StudentService<TDto> : BaseService<Student, TDto, int>, IStudentService<TDto>
        where TDto : class, new()
    {
        private IStudentRepository repository;

        public StudentService(IStudentRepository _repository, IHttpContextAccessor _httpContextAccessor)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this._httpContextAccessor = _httpContextAccessor;
        }
    }
}
