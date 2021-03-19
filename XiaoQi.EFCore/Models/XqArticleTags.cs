using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqArticleTags
    {
        public string Id { get; set; }
        public string TagId { get; set; }
        public string ArticleId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
