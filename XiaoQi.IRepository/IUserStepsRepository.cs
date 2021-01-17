using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiaoQi.Model;
namespace XiaoQi.IRepository
{
   public interface IUserStepsRepository:IBaseRepository<UserStepsDto>
    {
        IQueryable<UserStepsDto> GetAll();
    }
}
