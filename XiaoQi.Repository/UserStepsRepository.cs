using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiaoQi.EFCore;
using XiaoQi.EFCore.Models;
using XiaoQi.IRepository;
using XiaoQi.Model;

namespace XiaoQi.Repository
{
    public class UserStepsRepository : BaseRepository<UserStepsDto>, IUserStepsRepository
    {
        private readonly BlogContext _mySqlContext;
        public UserStepsRepository(BlogContext context) : base(context)
        {
            _mySqlContext = context;
        }

        public IQueryable<UserStepsDto> GetAll()
        {
            var res = from b in _mySqlContext.Set<Userinfo>()
                      join d in _mySqlContext.Set<UserSteps>()
                        on b.Id equals d.UserId
                      select new UserStepsDto { Id = b.Id, Sex = b.Sex, Userage = b.Userage, Username = b.Username, StepId = d.Id, UserSteps1 = d.UserSteps1 };
            return res;
        }
    }
}
