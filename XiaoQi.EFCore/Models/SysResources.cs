using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysResources
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Permission { get; set; }
        public string ParentId { get; set; }
        public int? Sort { get; set; }
        public byte? External { get; set; }
        public byte? Available { get; set; }
        public string Icon { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
