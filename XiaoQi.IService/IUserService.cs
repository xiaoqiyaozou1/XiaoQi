using System;
using System.Collections.Generic;
using System.Text;
using XiaoQi.EFCore;
using XiaoQi.EFCore.Models;

namespace XiaoQi.IService
{
    public interface IUserService : IBaseService<SysUser>
    {
        SysUser GetUserInfoByConutAndPwd(string count, string pwd);
    }
}
