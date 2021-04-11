using System;
using System.Collections.Generic;
using System.Text;
using XiaoQi.EFCore;
using XiaoQi.EFCore.Models;
using XiaoQi.IRepository;
using XiaoQi.IService;

namespace XiaoQi.Service
{
    public class UserInfoService : BaseService<SysUser>, IUserService
    {
        private readonly IBaseRepository<SysUser> _baseRepository;


        public UserInfoService(IBaseRepository<SysUser> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }

        public SysUser GetUserInfoByConutAndPwd(string count, string pwd)
        {
            var res = _baseRepository.QueryByLambada(o =>o.Username == count && o.Password == pwd);
            return res;
        }
    }



}
