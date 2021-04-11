using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XiaoQi.EFCore;
using XiaoQi.EFCore.Models;
using XiaoQi.IService;
using XiaoQi.Model;
using XiaoQi.Utilities;

namespace XiaoQi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize("MyPolicy")]
    public class SysUserController : ControllerBase
    {
        private readonly ISysUserService _sysUserService;

        private MessageModel messageModel = new MessageModel();
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysUsers()
        {
            var res = _sysUserService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 根据用户id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var data =await _sysUserService.QueryById(id);
            messageModel.response = data;
            return new JsonResult(messageModel);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSysUser(SysUser sysUser)
        {
           
            sysUser.Password = MD5Helper.MD5Encrypt32(sysUser.Password);
            var res = await _sysUserService.Add(sysUser);
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
        public async Task<IActionResult> UpdateSysUser(SysUser sysUser)
        {
            var res = await _sysUserService.Update(sysUser);
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
        [HttpDelete]
        public async Task<IActionResult> DeleteById(string id)
        {
            var res = await _sysUserService.Delete(id);
            if (res)
                messageModel.response = true;
            else
            {
                messageModel.response = false;
                messageModel.msg = "删除失败";
            }
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsersPage(int pageIndex, int pageSize, string userName)
        {
            if (string.IsNullOrEmpty(userName))
                userName = "";
            var data = _sysUserService.GetPageInfos(pageIndex, pageSize, out int total, x => x.Username.Contains(userName), x => x.CreateTime, true);
             messageModel.response = new
            {
                data,
                total
            };
            return new JsonResult(messageModel);
        }
    }
}
