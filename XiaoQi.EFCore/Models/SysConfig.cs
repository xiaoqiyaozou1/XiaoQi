using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysConfig
    {
        public string Id { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
