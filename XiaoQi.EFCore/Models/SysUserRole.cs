using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysUserRole
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
