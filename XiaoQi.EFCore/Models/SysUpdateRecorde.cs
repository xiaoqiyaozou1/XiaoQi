using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysUpdateRecorde
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public DateTime? RecordeTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
