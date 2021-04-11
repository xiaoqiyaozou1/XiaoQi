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
        public async Task<bool> Add(T t)
        {
            try
            {
                var res = await _baseRepository.Add(t);
                return res > 0;
            }
            catch (Exception e)
            {
               
                throw e;
            }
          
        }


        public async Task<bool> Delete(object id)
        {
            var res =await _baseRepository.DeleteById(id);
            return res;
        }

        public IQueryable<T> GetPageInfos<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            var res = _baseRepository.Query<S>(pageIndex, pageSize, whereLambda, orderByLambda, out total);
            return res; 
        }

        public Task<List<T>> Query(string where)
        {
            throw new NotImplementedException();
        }

        public List<T> Query()
        {
            var res = _baseRepository.Query();
            return res.ToList();
        }

        public async Task<T> QueryById(object id)
        {
            var res =await _baseRepository.QueryById(id);
            return res;
        }

        public T QueryByLambada(Expression<Func<T, bool>> whereExpression)
        {
            var res = _baseRepository.QueryByLambada(whereExpression);
            return res;
        }

        public async  Task<bool> Update(T t)
        {
            var res =await _baseRepository.Update(t);
            return res;
        }

   
    }
}
