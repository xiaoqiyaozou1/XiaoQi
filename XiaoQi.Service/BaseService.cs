using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XiaoQi.EFCore;
using XiaoQi.IRepository;
using XiaoQi.IService;

namespace XiaoQi.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task<bool> Add(T t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetPageInfos<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string where)
        {
            throw new NotImplementedException();
        }

        public List<T> Query()
        {
            var res = _baseRepository.Query();
            return res;
        }

        public Task<T> QueryById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryByWhereAsync(Expression<Func<T, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
