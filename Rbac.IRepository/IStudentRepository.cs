using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IRepository
{
    public interface IStudentRepository : IBaseRepository<Student, int>
    {

    }
}