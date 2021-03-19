using System;
using System.Collections.Generic;
using System.Text;
using XiaoQi.EFCore;
using XiaoQi.IRepository;
using XiaoQi.IService;

namespace XiaoQi.Service
{
    public class UserInfoService:BaseService<Userinfo>,IUserService
    {
        private readonly IBaseRepository<Userinfo>  _baseRepository;


        public UserInfoService(IBaseRepository<Userinfo> baseRepository) :base(baseRepository)
        {
            _baseRepository = baseRepository;
          
        }


    }



}
