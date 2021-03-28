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
    public class SysRoleController : ControllerBase
    {
        private readonly ISysRoleService _sysRoleService;

        private MessageModel messageModel = new MessageModel();
        public SysRoleController(ISysRoleService sysRoleService)
        {
            _sysRoleService = sysRoleService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysRoles()
        {
            var res = _sysRoleService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }
        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSysRoleById(string id)
        {
            try
            {
                var data = await _sysRoleService.QueryById(id);
                messageModel.response = data;
                return new JsonResult(messageModel);

            }
            catch (Exception ex)
            {
                messageModel.status = 500;
                messageModel.response = "数据获取失败";
                messageModel.success = false;
                return new JsonResult(messageModel);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSysRole(SysRole sysRole)
        {
            var res = await _sysRoleService.Add(sysRole);
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
        /// <param name="sysRole"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSysRole(SysRole sysRole)
        {
            var res = await _sysRoleService.Update(sysRole);
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
            var res = await _sysRoleService.Delete(id);
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
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRolesPage(int pageIndex, int pageSize, string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                roleName = "";
            var data = _sysRoleService.GetPageInfos(pageIndex, pageSize, out int total, o => o.Name.Contains(roleName), o => o.CreateTime, true);
            messageModel.response = new
            {
                data,
                total
            };
            return new JsonResult(messageModel);
        }

    }
}
