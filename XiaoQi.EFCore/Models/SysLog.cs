using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysLog
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string LogLevel { get; set; }
        public string Content { get; set; }
        public string Params { get; set; }
        public string SpiderType { get; set; }
        public string Ip { get; set; }
        public string Ua { get; set; }
        public string Os { get; set; }
        public string Browser { get; set; }
        public string RequestUrl { get; set; }
        public string Referer { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
