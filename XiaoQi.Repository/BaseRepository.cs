using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XiaoQi.EFCore;
using XiaoQi.IRepository;

namespace XiaoQi.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly MyContext _mySqlContext;
        public BaseRepository(MyContext context)
        {
            _mySqlContext = context;
        }
        public async Task<int> Add(TEntity model)
        {
            var res = await _mySqlContext.AddAsync<TEntity>(model);
            return await _mySqlContext.SaveChangesAsync();
        }

        public async Task<int> Add(List<TEntity> listEntity)
        {
            await _mySqlContext.AddRangeAsync(listEntity);
            return await _mySqlContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(TEntity model)
        {
            var res = _mySqlContext.Remove<TEntity>(model);
            return await _mySqlContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteById(object id)
        {
            var res = await _mySqlContext.FindAsync<TEntity>(id);
            return await _mySqlContext.SaveChangesAsync() > 0;
        }

        public  Task<bool> DeleteByIds(object[] ids)
        {           
            throw new NotImplementedException();
        }

    
        public List<TEntity> Query()
        {
            var res= _mySqlContext.Set<TEntity>();
            return res.ToList();
        }

        public Task<List<TEntity>> Query(string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> Query<TResult>(string strWhere, Expression<Func<TEntity, TResult>> expression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> QueryById(object objId)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> QueryById(object objId, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(Expression<Func<T, T2, T3, object[]>> joinExpression, Expression<Func<T, T2, T3, TResult>> selectExpression, Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TEntity entity, string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(object operateAnonymousObjects)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            throw new NotImplementedException();
        }
    }
}
