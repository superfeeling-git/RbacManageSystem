using Rbac.Entity;
using Rbac.IRepository;
using Rbac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using Rbac.Dtos;

namespace Rbac.Service
{
    public class GoodsCategoryService<TDto> : BaseService<GoodsCategory, TDto, int>, IGoodsCategoryService<TDto>
        where TDto : class, new()
    {
        private IGoodsCategoryRepository repository;

        public GoodsCategoryService(IGoodsCategoryRepository _repository, IHttpContextAccessor _httpContextAccessor)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
            this._httpContextAccessor = _httpContextAccessor;
        }
        
        public override Task<List<TDto>> ListAsync(Expression<Func<GoodsCategory, bool>> Condition = null)
        {
            return base.ListAsync(Condition);
        }


        private List<TreeDto> Nodes = new List<TreeDto>();

        public async Task<List<TreeDto>> GetNodes()
        {
            var List = await repository.ListAsync();

            foreach (var item in List.Where(m => m.ParnetID == 0))
            {
                //�ҵ�--���ӻ�(Һ����������)�����䡢ϴ�»�
                TreeDto treemodel = new TreeDto { value = item.CategoryId, label = item.CategoryName };
                GetSubNodes(treemodel, List);
                Nodes.Add(treemodel);
            }

            return Nodes;
        }

        /// <summary>
        /// ��ȡ�ڶ����ڵ�
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="list"></param>
        private void GetSubNodes(TreeDto tree, List<GoodsCategory> list)
        {
            foreach (var item in list.Where(m => m.ParnetID == tree.value))
            {
                TreeDto treemodel = new TreeDto { value = item.CategoryId, label = item.CategoryName };
                tree.children.Add(treemodel);
                GetSubNodes(treemodel, list);
            }
        }
    }
}
