using System;
using System.Collections.Generic;
using System.Text;
using XiaoQi.EFCore.Models;
using XiaoQi.IRepository;
using XiaoQi.IService;

namespace XiaoQi.Service
{
    public partial class SysConfigService : BaseService<SysConfig>, ISysConfigService
    {
        private readonly IBaseRepository<SysConfig> _baseRepository;


        public SysConfigService(IBaseRepository<SysConfig> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysLinkService : BaseService<SysLink>, ISysLinkService
    {
        private readonly IBaseRepository<SysLink> _baseRepository;


        public SysLinkService(IBaseRepository<SysLink> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysLogService : BaseService<SysLog>, ISysLogService
    {
        private readonly IBaseRepository<SysLog> _baseRepository;


        public SysLogService(IBaseRepository<SysLog> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysNoticeService : BaseService<SysNotice>, ISysNoticeService
    {
        private readonly IBaseRepository<SysNotice> _baseRepository;


        public SysNoticeService(IBaseRepository<SysNotice> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysResourcesService : BaseService<SysResources>, ISysResourcesService
    {
        private readonly IBaseRepository<SysResources> _baseRepository;


        public SysResourcesService(IBaseRepository<SysResources> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysRoleService : BaseService<SysRole>, ISysRoleService
    {
        private readonly IBaseRepository<SysRole> _baseRepository;


        public SysRoleService(IBaseRepository<SysRole> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysRoleResourcesService : BaseService<SysRoleResources>, ISysRoleResourcesService
    {
        private readonly IBaseRepository<SysRoleResources> _baseRepository;


        public SysRoleResourcesService(IBaseRepository<SysRoleResources> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysTemplateService : BaseService<SysTemplate>, ISysTemplateService
    {
        private readonly IBaseRepository<SysTemplate> _baseRepository;


        public SysTemplateService(IBaseRepository<SysTemplate> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysUpdateRecordeService : BaseService<SysUpdateRecorde>, ISysUpdateRecordeService
    {
        private readonly IBaseRepository<SysUpdateRecorde> _baseRepository;


        public SysUpdateRecordeService(IBaseRepository<SysUpdateRecorde> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysUserService : BaseService<SysUser>, ISysUserService
    {
        private readonly IBaseRepository<SysUser> _baseRepository;


        public SysUserService(IBaseRepository<SysUser> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class SysUserRoleService : BaseService<SysUserRole>, ISysUserRoleService
    {
        private readonly IBaseRepository<SysUserRole> _baseRepository;


        public SysUserRoleService(IBaseRepository<SysUserRole> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqArticleService : BaseService<XqArticle>, IXqArticleService
    {
        private readonly IBaseRepository<XqArticle> _baseRepository;


        public XqArticleService(IBaseRepository<XqArticle> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqArticleLookService : BaseService<XqArticleLook>, IXqArticleLookService
    {
        private readonly IBaseRepository<XqArticleLook> _baseRepository;


        public XqArticleLookService(IBaseRepository<XqArticleLook> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqArticleLoveService : BaseService<XqArticleLove>, IXqArticleLoveService
    {
        private readonly IBaseRepository<XqArticleLove> _baseRepository;


        public XqArticleLoveService(IBaseRepository<XqArticleLove> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqArticleTagsService : BaseService<XqArticleTags>, IXqArticleTagsService
    {
        private readonly IBaseRepository<XqArticleTags> _baseRepository;


        public XqArticleTagsService(IBaseRepository<XqArticleTags> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqCommentService : BaseService<XqComment>, IXqCommentService
    {
        private readonly IBaseRepository<XqComment> _baseRepository;


        public XqCommentService(IBaseRepository<XqComment> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqFileService : BaseService<XqFile>, IXqFileService
    {
        private readonly IBaseRepository<XqFile> _baseRepository;


        public XqFileService(IBaseRepository<XqFile> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqTagsService : BaseService<XqTags>, IXqTagsService
    {
        private readonly IBaseRepository<XqTags> _baseRepository;


        public XqTagsService(IBaseRepository<XqTags> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
    public partial class XqTypeService : BaseService<XqType>, IXqTypeService
    {
        private readonly IBaseRepository<XqType> _baseRepository;


        public XqTypeService(IBaseRepository<XqType> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;

        }
    }
}
