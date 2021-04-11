using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XiaoQi.IService;
using XiaoQi.Moudle.Authorizations;
using XiaoQi.Utilities;

namespace XiaoQi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration Configuration { get; }

        private IUserService _userService;
        private ISysRoleService _sysRoleService;
        private ISysResourcesService _sysResourcesService;
        private ISysUserRoleService _sysUserRoleService;
        private ISysRoleResourcesService _sysRoleResourcesService;
        private PermissionRequirement _permissionRequirement;
        public LoginController(IConfiguration configuration,
            IUserService userService,
            ISysRoleService sysRoleService,
            ISysResourcesService sysResourcesService,
            ISysUserRoleService sysUserRoleService,
            ISysRoleResourcesService sysRoleResourcesService,
            PermissionRequirement permissionRequirement)
        {
            Configuration = configuration;
            _userService = userService;
            _sysRoleService = sysRoleService;
            _sysResourcesService = sysResourcesService;
            _sysUserRoleService = sysUserRoleService;
            _sysRoleResourcesService = sysRoleResourcesService;
            _permissionRequirement = permissionRequirement;

        }
        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string userCount, string passWord)
        {
            try
            {
                var roleResourceAll1 = _sysRoleResourcesService.Query();
                passWord = MD5Helper.MD5Encrypt32(passWord);
                var userInfo = _userService.GetUserInfoByConutAndPwd(userCount, passWord);
                if (userInfo == null)
                {
                    return new JsonResult(null);
                }
                List<string> roleIds = new List<string>();
                var tmpUserRole = _sysUserRoleService.QueryByLambada(o => o.UserId == userInfo.Id);
                if (tmpUserRole != null)
                    roleIds = tmpUserRole.RoleId.Split(",").ToList();
                List<string> resoureIds = new List<string>();//资源 地址
                List<string> roles = new List<string>();
                //获取角色拥有得
                if (roleIds.Count > 0)
                {
                    var roleResourceAll = _sysRoleResourcesService.Query();
                    var roleAll = _sysRoleService.Query();
                    var resourceAll = _sysResourcesService.Query();
                    foreach (var item in roleIds)
                    {
                        var role = roleAll.Where(o => o.Id == item).FirstOrDefault().Name;
                        var resourceIds = roleResourceAll.Where(o => o.RoleId == item).FirstOrDefault()?.ResourcesId;
                        if (resourceIds != null)
                        {
                            var resourceList = resourceIds.Split(",").ToList();
                            foreach (var resource in resourceList)
                            {
                                var url = resourceAll.Where(o => o.Id == resource).FirstOrDefault()?.Url;
                                if (role != null && url != null)
                                {
                                    if (!roles.Contains(role))
                                        roles.Add(role);
                                    _permissionRequirement.Permissions.Add(new PermissionItem
                                    {
                                        Role = role,
                                        Url = url
                                    });
                                }
                            }
                        }



                    }
                }
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(60 * 60 * 24 * 365).ToString()));
                claims.AddRange(roles.Select(s => new Claim(ClaimTypes.Role, s)));
                var token = JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement);
                Log4NetHelper.Info("test", null);


                return new JsonResult(token);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
