using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiaoQi.Model;

namespace XiaoQi.IService
{
    public interface IUserStepsService
    {
        IQueryable<UserStepsDto> GetAll();
    }
}
