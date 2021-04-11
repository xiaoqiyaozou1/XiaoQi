using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XiaoQi.EFCore;
using XiaoQi.EFCore.Models;
using XiaoQi.IService;
using XiaoQi.Model;

namespace XiaoQi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize("MyPolicy")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserService _userService;

        private MessageModel messageModel = new MessageModel();
        public UserInfoController(IUserService userService, IUserStepsService userStepsService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserInfos()
        {
            var res = _userService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserInfo(SysUser sysUser)
        {
            var res = await _userService.Add(sysUser);
            if (res)
                messageModel.response = true;
            else
            {
                messageModel.response = false;
                messageModel.msg = "添加失败";
            }
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(SysUser sysUser)
        {
            var res = await _userService.Update(sysUser);
            if (res)
                messageModel.response = true;
            else
            {
                messageModel.response = false;
                messageModel.msg = "更新失败";
            }
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> DeleteById(string id)
        {
            var res = await _userService.Delete(id);
            if (res)
                messageModel.response = true;
            else
            {
                messageModel.response = false;
                messageModel.msg = "删除失败";
            }
            return new JsonResult(messageModel);
        }


    }
}
