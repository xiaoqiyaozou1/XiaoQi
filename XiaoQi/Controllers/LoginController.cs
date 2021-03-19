using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XiaoQi.Moudle.Authorizations;

namespace XiaoQi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "test"),
                    new Claim(JwtRegisteredClaimNames.Jti, "aaa"),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(60*60).ToString()) };
                claims.Add(new Claim(ClaimTypes.Role, "a"));

                List<PermissionItem> permissionItems = new List<PermissionItem>//这部分数据应该从数据库读取 如果想实时 在验证的地方从新获取最新的
                {
                    new PermissionItem
                    {
                        Role="a",
                        Url="/a"
                    }
                };
                PermissionRequirement permissionRequirement = new PermissionRequirement("", permissionItems, "Role", "Issuer", "Audience", null, TimeSpan.FromSeconds(60 * 60 * 24 * 365));
                var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xiaoqixiaoqixiaoqixiaoqixiaoqixiaoqixiaoqi"));//加密验证的key         
                var jwtCreds = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256); //根据key' 生成的标识
                permissionRequirement.SigningCredentials = jwtCreds;
                var token = JwtToken.BuildJwtToken(claims.ToArray(), permissionRequirement);
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
