using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysLink
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Qq { get; set; }
        public string Favicon { get; set; }
        public byte? Status { get; set; }
        public byte? HomePageDisplay { get; set; }
        public string Remark { get; set; }
        public string Source { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
