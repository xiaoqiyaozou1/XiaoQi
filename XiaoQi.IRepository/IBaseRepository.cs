using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XiaoQi.IRepository
{
   public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// 根据主键ID查数据
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<TEntity> QueryById(object objId);
        /// <summary>
        /// 根据一组ID查出一个集合
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> QueryByIDs(object[] lstIds);

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> Add(TEntity model);

        /// <summary>
        /// 添加多个实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        Task<int> Add(List<TEntity> listEntity);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteById(object id);

        /// <summary>
        /// 根据整个实体删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Delete(TEntity model);

        /// <summary>
        /// 删除一组数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteByIds(object[] ids);

        /// <summary>
        /// 根据实体更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity model);

        /// <summary>
        /// 根据条件 和实体更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity, string strWhere);
        Task<bool> Update(object operateAnonymousObjects);

        Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");

        IQueryable<TEntity> Query();
   
        IQueryable<TEntity> Query<S>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, S>> orderByLambda, out int total);

        TEntity QueryByLambada(Expression<Func<TEntity, bool>> whereExpression);
    }
}
