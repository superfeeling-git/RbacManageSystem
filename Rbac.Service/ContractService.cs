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
    public class ContractService<TDto> : BaseService<Contract, TDto, int>, IContractService<TDto>
        where TDto : class, new()
    {
        private IContractRepository repository;

        public ContractService(IContractRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
        }
    }
}
