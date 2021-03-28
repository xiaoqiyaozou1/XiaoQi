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
    public class SysRoleResourcesController : ControllerBase
    {
        private readonly ISysRoleResourcesService _sysRoleResourcesService;

        private MessageModel messageModel = new MessageModel();
        public SysRoleResourcesController(ISysRoleResourcesService sysRoleResourcesService)
        {
            _sysRoleResourcesService = sysRoleResourcesService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysRoleResourcess()
        {
            var res = _sysRoleResourcesService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSysRoleResources(SysRoleResources sysRoleResources)
        {
            var res = await _sysRoleResourcesService.Add(sysRoleResources);
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
        /// <param name="sysRoleResources"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSysRoleResources(SysRoleResources sysRoleResources)
        {
            var res = await _sysRoleResourcesService.Update(sysRoleResources);
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
            var res = await _sysRoleResourcesService.Delete(id);
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
        /// 根据roleId 获取权限数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleResourceByRoleId(string roleId)
        {
            var data =  _sysRoleResourcesService.QueryByLambada(o => o.RoleId == roleId);
            messageModel.response = data;
            return new JsonResult(messageModel);
        }
    }
}
