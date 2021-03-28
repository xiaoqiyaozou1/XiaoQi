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
    public class SysLinkController : ControllerBase
    {
        private readonly ISysLinkService _sysLinkService;

        private MessageModel messageModel = new MessageModel();
        public SysLinkController(ISysLinkService sysLinkService)
        {
            _sysLinkService = sysLinkService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysLinks()
        {
            var res = _sysLinkService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSysLink(SysLink sysLink)
        {
            var res = await _sysLinkService.Add(sysLink);
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
        /// <param name="sysLink"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSysLink(SysLink sysLink)
        {
            var res = await _sysLinkService.Update(sysLink);
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
            var res = await _sysLinkService.Delete(id);
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
        /// <param name="linkName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysLinksPage(int pageIndex, int pageSize, string linkName)
        {
            var data = _sysLinkService.GetPageInfos(pageIndex, pageSize, out int total, o => o.Name.Contains(linkName), o => o.CreateTime, true);
            messageModel.response = new
            {
                data,
                total
            };
            return new JsonResult(messageModel);
        }
    }
}
