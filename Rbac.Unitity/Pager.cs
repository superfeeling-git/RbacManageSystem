using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Rbac.Unitity
{
    public static class Pager
    {
        public static (int,List<TTagget>) PagedList<TSource, TTagget>(this IQueryable<TSource> query,int PageIndex = 1,int PageSize = 10)
        {
            return new(query.Count(), query.Page(PageIndex,PageSize).MapToList<TSource,TTagget>());
        }
    }
}
