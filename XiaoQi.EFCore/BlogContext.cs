using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XiaoQi.EFCore.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysConfig> SysConfig { get; set; }
        public virtual DbSet<SysLink> SysLink { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysNotice> SysNotice { get; set; }
        public virtual DbSet<SysResources> SysResources { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleResources> SysRoleResources { get; set; }
        public virtual DbSet<SysTemplate> SysTemplate { get; set; }
        public virtual DbSet<SysUpdateRecorde> SysUpdateRecorde { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserRole> SysUserRole { get; set; }
        public virtual DbSet<XqArticle> XqArticle { get; set; }
        public virtual DbSet<XqArticleLook> XqArticleLook { get; set; }
        public virtual DbSet<XqArticleLove> XqArticleLove { get; set; }
        public virtual DbSet<XqArticleTags> XqArticleTags { get; set; }
        public virtual DbSet<XqComment> XqComment { get; set; }
        public virtual DbSet<XqFile> XqFile { get; set; }
        public virtual DbSet<XqTags> XqTags { get; set; }
        public virtual DbSet<XqType> XqType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysConfig>(entity =>
            {
                entity.ToTable("sys_config");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigKey)
                    .HasColumnName("config_key")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("配置关键字");

                entity.Property(e => e.ConfigValue)
                    .HasColumnName("config_value")
                    .HasComment("配置项内容");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<SysLink>(entity =>
            {
                entity.ToTable("sys_link");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasComment("链接介绍");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("友链站长邮箱");

                entity.Property(e => e.Favicon)
                    .HasColumnName("favicon")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HomePageDisplay)
                    .HasColumnName("home_page_display")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否首页显示");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("链接名");

                entity.Property(e => e.Qq)
                    .HasColumnName("qq")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasComment("友链站长QQ");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("enum('ADMIN','AUTOMATIC')")
                    .HasDefaultValueSql("'ADMIN'")
                    .HasComment("来源：管理员添加、自动申请");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("链接地址");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.ToTable("sys_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("评论时的浏览器类型");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("日志内容（业务操作）");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("操作用户的ip");

                entity.Property(e => e.LogLevel)
                    .IsRequired()
                    .HasColumnName("log_level")
                    .HasColumnType("enum('ERROR','WARN','INFO')")
                    .HasDefaultValueSql("'INFO'")
                    .HasComment("日志级别");

                entity.Property(e => e.Os)
                    .HasColumnName("os")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("评论时的系统类型");

                entity.Property(e => e.Params)
                    .HasColumnName("params")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("请求参数（业务操作）");

                entity.Property(e => e.Referer)
                    .HasColumnName("referer")
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasComment("请求来源地址");

                entity.Property(e => e.RequestUrl)
                    .HasColumnName("request_url")
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasComment("请求的路径");

                entity.Property(e => e.SpiderType)
                    .HasColumnName("spider_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("爬虫类型（当访问者被鉴定为爬虫时该字段表示爬虫的类型）");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("enum('SYSTEM','VISIT','ERROR')")
                    .HasDefaultValueSql("'SYSTEM'")
                    .HasComment("日志类型（系统操作日志，用户访问日志，异常记录日志）");

                entity.Property(e => e.Ua)
                    .HasColumnName("ua")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("操作用户的user_agent");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("已登录用户ID");
            });

            modelBuilder.Entity<SysNotice>(entity =>
            {
                entity.ToTable("sys_notice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("通知的内容");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("enum('RELEASE','NOT_RELEASE')")
                    .HasDefaultValueSql("'NOT_RELEASE'")
                    .HasComment("通知状态");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("通知的标题");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("被通知的用户ID");
            });

            modelBuilder.Entity<SysResources>(entity =>
            {
                entity.ToTable("sys_resources");

                entity.HasIndex(e => e.ParentId)
                    .HasName("idx_sys_resource_parent_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.External)
                    .HasColumnName("external")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasComment("是否外部链接");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("菜单图标");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Permission)
                    .HasColumnName("permission")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("sys_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("角色名");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<SysRoleResources>(entity =>
            {
                entity.ToTable("sys_role_resources");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(7200)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.ResourcesId)
                    .IsRequired()
                    .HasColumnName("resources_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<SysTemplate>(entity =>
            {
                entity.ToTable("sys_template");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.RefKey)
                    .HasColumnName("ref_key")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("键");

                entity.Property(e => e.RefValue)
                    .HasColumnName("ref_value")
                    .HasComment("模板内容");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<SysUpdateRecorde>(entity =>
            {
                entity.ToTable("sys_update_recorde");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasComment("更新记录备注");

                entity.Property(e => e.RecordeTime)
                    .HasColumnName("recorde_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("项目更新时间");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("更新版本");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("sys_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("头像地址");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.Blog)
                    .HasColumnName("blog")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("个人博客地址");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("公司");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("注册时间");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("邮箱地址");

                entity.Property(e => e.Experience)
                    .HasColumnName("experience")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("经验值");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("smallint(2)")
                    .HasComment("性别");

                entity.Property(e => e.LastLoginIp)
                    .HasColumnName("last_login_ip")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("最近登录IP");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnName("last_login_time")
                    .HasComment("最近登录时间");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("地址");

                entity.Property(e => e.LoginCount)
                    .HasColumnName("login_count")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("登录次数");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("手机号");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''")
                    .HasComment("昵称");

                entity.Property(e => e.Notification)
                    .HasColumnName("notification")
                    .HasColumnType("tinyint(2) unsigned")
                    .HasComment("通知：(1：通知显示消息详情，2：通知不显示详情)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("登录密码");

                entity.Property(e => e.Privacy)
                    .HasColumnName("privacy")
                    .HasColumnType("tinyint(2)")
                    .HasComment("隐私（1：公开，0：不公开）");

                entity.Property(e => e.Qq)
                    .HasColumnName("qq")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("QQ");

                entity.Property(e => e.RegIp)
                    .HasColumnName("reg_ip")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("注册IP");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("用户备注");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("金币值");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("enum('GITHUB','GITEE','WEIBO','DINGTALK','BAIDU','CSDN','CODING','OSCHINA','TENCENT_CLOUD','ALIPAY','TAOBAO','QQ','WECHAT','GOOGLE','FACEBOOK')")
                    .HasComment("用户来源");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1) unsigned")
                    .HasComment("用户状态");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasColumnType("enum('ROOT','ADMIN','USER')")
                    .HasDefaultValueSql("'ADMIN'")
                    .HasComment("超级管理员、管理员、普通用户");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("用户唯一表示(第三方网站)");
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.ToTable("sys_user_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XqArticle>(entity =>
            {
                entity.ToTable("xq_article");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("主键存guid");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否开启评论");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("mediumtext")
                    .HasComment("文章内容");

                entity.Property(e => e.ContentMd)
                    .HasColumnName("content_md")
                    .HasColumnType("mediumtext")
                    .HasComment("markdown版的文章内容");

                entity.Property(e => e.CoverImage)
                    .HasColumnName("cover_image")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("文章封面图片");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasComment("文章简介，最多200字");

                entity.Property(e => e.IsMarkdown)
                    .HasColumnName("is_markdown")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("文章关键字，优化搜索");

                entity.Property(e => e.Original)
                    .HasColumnName("original")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否原创");

                entity.Property(e => e.QrcodePath)
                    .HasColumnName("qrcode_path")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("文章专属二维码地址");

                entity.Property(e => e.Recommended)
                    .HasColumnName("recommended")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否推荐");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasComment("状态");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("文章标题");

                entity.Property(e => e.Top)
                    .HasColumnName("top")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否置顶");

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasColumnName("type_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("类型");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<XqArticleLook>(entity =>
            {
                entity.ToTable("xq_article_look");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("主键GUID");

                entity.Property(e => e.ArticleId)
                    .IsRequired()
                    .HasColumnName("article_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("文章ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.LookTime)
                    .HasColumnName("look_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("浏览时间");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("已登录用户ID");

                entity.Property(e => e.UserIp)
                    .HasColumnName("user_ip")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("用户IP");
            });

            modelBuilder.Entity<XqArticleLove>(entity =>
            {
                entity.ToTable("xq_article_love");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ArticleId)
                    .IsRequired()
                    .HasColumnName("article_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("文章ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.LoveTime)
                    .HasColumnName("love_time")
                    .HasComment("浏览时间");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("已登录用户ID");

                entity.Property(e => e.UserIp)
                    .HasColumnName("user_ip")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("用户IP");
            });

            modelBuilder.Entity<XqArticleTags>(entity =>
            {
                entity.ToTable("xq_article_tags");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ArticleId)
                    .IsRequired()
                    .HasColumnName("article_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("文章ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasColumnName("tag_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("标签表主键");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<XqComment>(entity =>
            {
                entity.ToTable("xq_comment");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("评论时的地址");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("评论人的头像地址");

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("评论时的浏览器类型");

                entity.Property(e => e.BrowserShortName)
                    .HasColumnName("browser_short_name")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("评论时的浏览器的简称");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("评论的内容");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("评论人的邮箱地址（未登录用户）");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("评论时的ip");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("纬度");

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("经度");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasComment("评论人的昵称（未登录用户）");

                entity.Property(e => e.Oppose)
                    .HasColumnName("oppose")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("反对（踩）");

                entity.Property(e => e.Os)
                    .HasColumnName("os")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("评论时的系统类型");

                entity.Property(e => e.OsShortName)
                    .HasColumnName("os_short_name")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("评论时的系统的简称");

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("pid")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("父级评论的id");

                entity.Property(e => e.Qq)
                    .HasColumnName("qq")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasComment("评论人的QQ（未登录用户）");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("备注（审核不通过时添加）");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("被评论的文章或者页面的ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("enum('VERIFYING','APPROVED','REJECT','DELETED')")
                    .HasDefaultValueSql("'VERIFYING'")
                    .HasComment("评论的状态");

                entity.Property(e => e.Support)
                    .HasColumnName("support")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("支持（赞）");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("评论人的网站地址（未登录用户）");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasComment("评论人的ID");
            });

            modelBuilder.Entity<XqFile>(entity =>
            {
                entity.ToTable("xq_file");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnName("create_time");

                entity.Property(e => e.FileHash)
                    .HasColumnName("file_hash")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasColumnName("file_path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullFilePath)
                    .HasColumnName("full_file_path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.OriginalFileName)
                    .HasColumnName("original_file_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.StorageType)
                    .HasColumnName("storage_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnName("update_time");

                entity.Property(e => e.UploadEndTime).HasColumnName("upload_end_time");

                entity.Property(e => e.UploadStartTime).HasColumnName("upload_start_time");

                entity.Property(e => e.UploadType)
                    .HasColumnName("upload_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<XqTags>(entity =>
            {
                entity.ToTable("xq_tags");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("描述");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("书签名");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<XqType>(entity =>
            {
                entity.ToTable("xq_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasColumnType("tinyint(1) unsigned")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否可用");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("添加时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("类型介绍");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("图标");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("文章类型名");

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("pid")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(10)")
                    .HasComment("排序");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
