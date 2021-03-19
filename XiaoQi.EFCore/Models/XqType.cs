using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqType
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Sort { get; set; }
        public string Icon { get; set; }
        public byte? Available { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
