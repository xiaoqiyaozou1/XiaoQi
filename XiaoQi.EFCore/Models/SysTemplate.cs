using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysTemplate
    {
        public string Id { get; set; }
        public string RefKey { get; set; }
        public string RefValue { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
