using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XiaoQi.EFCore;
using XiaoQi.EFCore.Models;
using XiaoQi.IRepository;

namespace XiaoQi.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly BlogContext _mySqlContext;
        public BaseRepository(BlogContext context)
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
            _mySqlContext.Remove<TEntity>(res);
            return await _mySqlContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteByIds(object[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                var res = await _mySqlContext.FindAsync<TEntity>(ids[i]);
                _mySqlContext.Remove<TEntity>(res);
            }
            return await _mySqlContext.SaveChangesAsync() > 0;

        }

        public IQueryable<TEntity> Query()
        {
            var res = _mySqlContext.Set<TEntity>();
            return res;
        }

        public IQueryable<TEntity> Query<S>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, S>> orderByLambda, out int total)
        {
            total = _mySqlContext.Set<TEntity>().Where(whereExpression).ToList().Count;
            var res = _mySqlContext.Set<TEntity>()
                .Where<TEntity>(whereExpression)
                .OrderBy<TEntity, S>(orderByLambda)
                .Skip<TEntity>(pageSize * (pageIndex - 1))
                .Take<TEntity>(pageSize)
                .AsQueryable<TEntity>();
               
            return res;

        }
        public async Task<TEntity> QueryById(object objId)
        {
            return await _mySqlContext.FindAsync<TEntity>(objId);
        }


        public async Task<IQueryable<TEntity>> QueryByIDs(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(TEntity model)
        {
             _mySqlContext.Update<TEntity>(model);
             var res = await _mySqlContext.SaveChangesAsync();
            return res > 0;

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
