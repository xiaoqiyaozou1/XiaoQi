using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using XiaoQi.EFCore;
using Microsoft.EntityFrameworkCore;
using XiaoQi.IService;
using XiaoQi.Service;
using XiaoQi.IRepository;
using XiaoQi.Repository;
using Autofac;
using XiaoQi.Moudle.Authorizations;
using Swashbuckle.AspNetCore.Filters;
using XiaoQi.Filter;
using XiaoQi.EFCore.Models;
using Microsoft.Extensions.FileProviders;
using XiaoQi.Utilities;
using Microsoft.AspNetCore.StaticFiles;

namespace XiaoQi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var basePath = AppContext.BaseDirectory;
            //var log4NetPath = Path.Combine(basePath, "Log4net.config");
            Log4NetHelper.Configure();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            });



            services.AddDbContext<BlogContext>(o => o.UseMySQL(Configuration.GetConnectionString("MysqlCon")));

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", Configuration.GetValue<string>("StoredFilesPath"));
            FileHelper.CheckDirExist(filePath);
            var physicalProvider = new PhysicalFileProvider(filePath);

            // To list physical files in the temporary files folder, use:
            //var physicalProvider = new PhysicalFileProvider(Path.GetTempPath());

            services.AddSingleton<IFileProvider>(physicalProvider);

            services.AddAuthorizationSetup();//权限认证

            //Swagger 相关注册
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XiaoQi API", Version = "v1" });

                //为Swagger json 和 UI 增加注释信息
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // 开启加权小锁

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // Jwt Bearer 认证，必须是 oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("XiaoQiAllowOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:8080")
                    .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
        }
        //Autofac容器
        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();//注册仓储
            //builder.RegisterType<UserInfoService>().As<IUserService>().InstancePerLifetimeScope();
            var basePath = AppContext.BaseDirectory;
            var repositoryPath = Path.Combine(basePath, "XiaoQi.Repository.dll");
            var assemblysServices = Assembly.LoadFrom(repositoryPath);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency();

            var servicesPath = Path.Combine(basePath, "XiaoQi.Service.dll");
            var assemblysRepository = Assembly.LoadFrom(servicesPath);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("XiaoQiAllowOrigins");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;


            });
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", Configuration.GetValue<string>("StoredFilesPath"));
            FileHelper.CheckDirExist(filePath);
            var dir = new DirectoryBrowserOptions();
            dir.FileProvider = new PhysicalFileProvider(filePath);
            app.UseDirectoryBrowser(dir);

            var staticFile = new StaticFileOptions();

            staticFile.FileProvider = new PhysicalFileProvider(filePath);
            //手动设置MIME Type,或者设置一个默认值， 以解决某些文件MIME Type文件识别不到，出现404错误
            staticFile.ServeUnknownFileTypes = true;
            staticFile.DefaultContentType = "text/plain;charset=utf-8";//设置默认MIME Type
            var provider = new FileExtensionContentTypeProvider();//使用一组默认映射创建新的提供程序
            provider.Mappings[".txt"] = "text/plain;charset=utf-8";//手动设置对应MIME Type
            provider.Mappings.Add(".log", "text/plain");//手动设置对应MIME Type
            staticFile.ContentTypeProvider = provider; //将文件映射到内容类型

            app.UseStaticFiles(staticFile);
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    DefaultContentType = "text/plain;charset=utf-8"//设置默认MIME Type
            //});


            app.UseRouting();

            //认证
            app.UseAuthentication();
            //授权
            app.UseAuthorization();





            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
