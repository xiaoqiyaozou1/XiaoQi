using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqTags
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
