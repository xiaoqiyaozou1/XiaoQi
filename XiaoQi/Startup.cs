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

            services.AddAuthorizationSetup();//Ȩ����֤

            //Swagger ���ע��
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XiaoQi API", Version = "v1" });

                //ΪSwagger json �� UI ����ע����Ϣ
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // ������ȨС��

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // ��header�����token�����ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // Jwt Bearer ��֤�������� oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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
        //Autofac����
        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();//ע��ִ�
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
            //�ֶ�����MIME Type,��������һ��Ĭ��ֵ�� �Խ��ĳЩ�ļ�MIME Type�ļ�ʶ�𲻵�������404����
            staticFile.ServeUnknownFileTypes = true;
            staticFile.DefaultContentType = "text/plain;charset=utf-8";//����Ĭ��MIME Type
            var provider = new FileExtensionContentTypeProvider();//ʹ��һ��Ĭ��ӳ�䴴���µ��ṩ����
            provider.Mappings[".txt"] = "text/plain;charset=utf-8";//�ֶ����ö�ӦMIME Type
            provider.Mappings.Add(".log", "text/plain");//�ֶ����ö�ӦMIME Type
            staticFile.ContentTypeProvider = provider; //���ļ�ӳ�䵽��������

            app.UseStaticFiles(staticFile);
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    DefaultContentType = "text/plain;charset=utf-8"//����Ĭ��MIME Type
            //});


            app.UseRouting();

            //��֤
            app.UseAuthentication();
            //��Ȩ
            app.UseAuthorization();





            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
