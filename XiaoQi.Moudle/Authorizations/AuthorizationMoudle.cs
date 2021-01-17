using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace XiaoQi.Moudle.Authorizations
{
    public static class AuthorizationMoudle
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xiaoqixiaoqixiaoqixiaoqixiaoqixiaoqixiaoqi"));//加密验证的key         
            var jwtCreds = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256); //根据key' 生成的标识
            var permissions = new List<PermissionItem>();//用户角色和用户拥有的api 集合 ，该角色只能访问其拥有的api   
            
            var jwtRequirement = new PermissionRequirement(
                "",
                permissions,
                ClaimTypes.Role,
                "Issuer",
                "Audience",
                jwtCreds,
                TimeSpan.FromSeconds(60 * 60)
            );

            services.AddSingleton(jwtRequirement);//将该资源注册，可以在验证处理器种设置其值
            //注册策略授权
            services.AddAuthorizationCore(o =>
            {
                o.AddPolicy("MyPolicy", policy => policy.Requirements.Add(jwtRequirement));
            });

            //验证参数设置
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtKey,
                ValidateIssuer = true,
                ValidIssuer = "Issuer",//发行人
                ValidateAudience = true,
                ValidAudience = "Audience",//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30),
                RequireExpirationTime = true,
            };

            // 开启Bearer认证
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = nameof(ApiResponseHandler);
                o.DefaultForbidScheme = nameof(ApiResponseHandler);
            })
             // 添加JwtBearer服务
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = tokenValidationParameters;
                 o.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         // 如果过期，则把<是否过期>添加到，返回头信息中
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             })
             .AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });

            // 注入权限处理器
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}