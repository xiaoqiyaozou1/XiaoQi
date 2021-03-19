using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqArticle
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string CoverImage { get; set; }
        public string QrcodePath { get; set; }
        public byte? IsMarkdown { get; set; }
        public string Content { get; set; }
        public string ContentMd { get; set; }
        public byte? Top { get; set; }
        public string TypeId { get; set; }
        public byte? Status { get; set; }
        public byte? Recommended { get; set; }
        public byte? Original { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public byte? Comment { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
