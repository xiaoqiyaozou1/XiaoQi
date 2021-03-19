using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysRoleResources
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string ResourcesId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
