using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XiaoQi.IService
{
    public interface IBaseService<T>
    {
        List<T> Query();

        Task<List<T>> Query(string where);

      

        Task<T> QueryById(Object id);


        IQueryable<T> GetPageInfos<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda,
                                                    bool isAsc);

        Task<bool> Add(T t);

        Task<bool> Update(T t);

        Task<bool> Delete(Object id);

        T QueryByLambada(Expression<Func<T, bool>> whereExpression);
    }
}
