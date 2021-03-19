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
    public class XqTypeController : ControllerBase
        {
            private readonly IXqTypeService    _xqTypeService;

            private MessageModel messageModel = new MessageModel();
            public XqTypeController (IXqTypeService xqTypeService)
            {
                _xqTypeService = xqTypeService;
            }
            /// <summary>
            /// 获取
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public IActionResult GetXqTypes()
            {
                var res = _xqTypeService.Query();
                messageModel.response = res;
                return new JsonResult(messageModel);
            }

            /// <summary>
            /// 添加
            /// </summary>
            /// <param name="userinfo"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<IActionResult> AddXqType(XqType xqType)
            {
                var res = await _xqTypeService.Add(xqType);
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
            /// <param name="xqType"></param>
            /// <returns></returns>
            [HttpPut]
            public async Task<IActionResult> UpdateXqType(XqType xqType)
            {
                var res = await _xqTypeService.Update(xqType);
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
                var res = await _xqTypeService.Delete(id);
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
