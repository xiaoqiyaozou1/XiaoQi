using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqArticleLove
    {
        public string Id { get; set; }
        public string ArticleId { get; set; }
        public string UserId { get; set; }
        public string UserIp { get; set; }
        public DateTime? LoveTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
