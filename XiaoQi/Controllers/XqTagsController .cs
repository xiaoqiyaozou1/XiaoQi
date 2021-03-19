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
    public class XqTagsController : ControllerBase
        {
            private readonly IXqTagsService    _xqTagsService;

            private MessageModel messageModel = new MessageModel();
            public XqTagsController (IXqTagsService xqTagsService)
            {
                _xqTagsService = xqTagsService;
            }
            /// <summary>
            /// 获取
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public IActionResult GetXqTagss()
            {
                var res = _xqTagsService.Query();
                messageModel.response = res;
                return new JsonResult(messageModel);
            }

            /// <summary>
            /// 添加
            /// </summary>
            /// <param name="userinfo"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<IActionResult> AddXqTags(XqTags xqTags)
            {
                var res = await _xqTagsService.Add(xqTags);
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
            /// <param name="xqTags"></param>
            /// <returns></returns>
            [HttpPut]
            public async Task<IActionResult> UpdateXqTags(XqTags xqTags)
            {
                var res = await _xqTagsService.Update(xqTags);
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
                var res = await _xqTagsService.Delete(id);
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
