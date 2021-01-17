using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XiaoQi.IService;

namespace XiaoQi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize("MyPolicy")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IUserStepsService _userStepsService;
        public UserInfoController(IUserService userService, IUserStepsService userStepsService)
        {
            _userService = userService;
            _userStepsService = userStepsService;
        }
        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfos()
        {
            var res = _userService.Query();
            return new JsonResult(res);
        }
        /// <summary>
        /// 获取所有的用户信息和相关步数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserSteps()
        {
            var res = _userStepsService.GetAll();
            return new JsonResult(res);
        }
    }
}
