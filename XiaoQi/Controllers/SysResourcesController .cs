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
    public class SysResourcesController : ControllerBase
    {
        private readonly ISysResourcesService _sysResourcesService;

        private MessageModel messageModel = new MessageModel();
        public SysResourcesController(ISysResourcesService sysResourcesService)
        {
            _sysResourcesService = sysResourcesService;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysResourcess()
        {
            var res = _sysResourcesService.Query();
            messageModel.response = res;
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSysResoureceById(string id)
        {
            try
            {
                var data = await _sysResourcesService.QueryById(id);
                messageModel.response = data;
                return new JsonResult(messageModel);
            }
            catch (Exception)
            {
                messageModel.status = 500;
                messageModel.success = false;
                return new JsonResult(messageModel);
            }
        }



        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sysResources"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSysResources(SysResources sysResources)
        {
            var res = await _sysResourcesService.Add(sysResources);
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
        /// <param name="sysResources"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSysResources(SysResources sysResources)
        {
            var res = await _sysResourcesService.Update(sysResources);
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
            var res = await _sysResourcesService.Delete(id);
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
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSysResourecesPage(int pageIndex, int pageSize, string name)
        {
            if (string.IsNullOrEmpty(name))
                name = "";
            var data = _sysResourcesService.GetPageInfos(pageIndex, pageSize, out int total, o => o.Name.Contains(name), o => o.CreateTime, true);
            messageModel.response = new
            {
                data,
                total
            };
            return new JsonResult(messageModel);
        }

        /// <summary>
        /// 返回树状资源数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTreeResources()
        {
            List<TreeModel> treeModels  = new List<TreeModel>();
            List<TreeModel> tmpModels = new List<TreeModel>();
            var listData = _sysResourcesService.Query();
            foreach (var item in listData)
            {
                tmpModels.Add(new TreeModel
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Name = item.Name,

                });
            }
            tmpModels = tmpModels.OrderBy(o => o.ParentId).ToList();
            foreach (var item in tmpModels)
            {
                if (item.ParentId == "0")
                {
                    treeModels.Add(item);
                }
                else
                {
                    //这个地方是 最难理解得地方，我一直在想如何找他们得父节点，就是想通过一层一层去找，这种想法就是错的，
                    //正确得做法是只要让子节点加载到父节点，就可以了；
                    var parent = tmpModels.Where(x => x.Id == item.ParentId).FirstOrDefault();
               
                    parent.Children.Add(item);
                }
            }
            messageModel.response= Newtonsoft.Json.JsonConvert.SerializeObject(treeModels);
           
            return new JsonResult(messageModel);
        }

    }
}
