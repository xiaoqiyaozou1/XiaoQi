using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class XqArticleController : ControllerBase
    {
        private readonly IXqArticleService _xqArticleService;

        private MessageModel messageModel = new MessageModel();
        public XqArticleController(IXqArticleService xqArticleService)
        {
            _xqArticleService = xqArticleService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetXqArticles()
        {
            var res = _xqArticleService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 根据id获取文章信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetXqArticleById(string id)
        {
            var res = await _xqArticleService.QueryById(id);
            messageModel.response = res;
            return new JsonResult(messageModel);
        }



        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="xqArticle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddXqArticle(XqArticle xqArticle)
        {
            try
            {
                var res = await _xqArticleService.Add(xqArticle);
                if (res)
                    messageModel.response = true;
                else
                {
                    messageModel.response = false;
                    messageModel.msg = "添加失败";
                }
                return new JsonResult(messageModel);
            }
            catch (Exception e)
            {

                throw;
            }

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="xqArticle"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateXqArticle(XqArticle xqArticle)
        {
            var res = await _xqArticleService.Update(xqArticle);
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
            var res = await _xqArticleService.Delete(id);
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
        /// 博客分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetArticlePage(int pageIndex, int pageSize, string title)
        {
            if (string.IsNullOrEmpty(title))
                title = "";
            var data = _xqArticleService.GetPageInfos(pageIndex, pageSize, out int total, (x) => x.Title.Contains(title), (x) => x.CreateTime, true);
            messageModel.response = new
            {
                data,
                total
            };
            return new JsonResult(messageModel);
        }

    }
}
