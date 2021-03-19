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
    public class SysUpdateRecordeController : ControllerBase
        {
            private readonly ISysUpdateRecordeService    _sysUpdateRecordeService;

            private MessageModel messageModel = new MessageModel();
            public SysUpdateRecordeController (ISysUpdateRecordeService sysUpdateRecordeService)
            {
                _sysUpdateRecordeService = sysUpdateRecordeService;
            }
            /// <summary>
            /// 获取
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public IActionResult GetSysUpdateRecordes()
            {
                var res = _sysUpdateRecordeService.Query();
                messageModel.response = res;
                return new JsonResult(messageModel);
            }

            /// <summary>
            /// 添加
            /// </summary>
            /// <param name="userinfo"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<IActionResult> AddSysUpdateRecorde(SysUpdateRecorde sysUpdateRecorde)
            {
                var res = await _sysUpdateRecordeService.Add(sysUpdateRecorde);
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
            /// <param name="sysUpdateRecorde"></param>
            /// <returns></returns>
            [HttpPut]
            public async Task<IActionResult> UpdateSysUpdateRecorde(SysUpdateRecorde sysUpdateRecorde)
            {
                var res = await _sysUpdateRecordeService.Update(sysUpdateRecorde);
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
                var res = await _sysUpdateRecordeService.Delete(id);
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
