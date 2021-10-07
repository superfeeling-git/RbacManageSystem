using Rbac.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Service
{
    public class Recurve
    {
        /// <summary>
        /// 获取第二级节点
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="list"></param>
        public void GetSubNodes(TreeDto tree, List<CategoryDto> list)
        {
            foreach (var item in list.Where(m => m.ParentId == tree.value))
            {
                TreeDto treemodel = new TreeDto { value = item.CategoryId, label = item.CategoryName };
                tree.children.Add(treemodel);
                GetSubNodes(treemodel, list);
            }
        }
    }
}
