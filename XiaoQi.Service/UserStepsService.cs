using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiaoQi.IRepository;
using XiaoQi.IService;
using XiaoQi.Model;

namespace XiaoQi.Service
{
    public class UserStepsService : IUserStepsService
    {
        private readonly IUserStepsRepository _userStepsRepository;
        public UserStepsService(IUserStepsRepository userStepsRepository)
        {
            _userStepsRepository = userStepsRepository;
        }
        public IQueryable<UserStepsDto> GetAll()
        {
            return _userStepsRepository.GetAll();
        }
    }
}
