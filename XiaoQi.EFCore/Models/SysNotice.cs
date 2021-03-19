using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysNotice
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
