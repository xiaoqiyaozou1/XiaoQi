using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqComment
    {
        public string Id { get; set; }
        public string Sid { get; set; }
        public string UserId { get; set; }
        public string Pid { get; set; }
        public string Qq { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string Ip { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public string Address { get; set; }
        public string Os { get; set; }
        public string OsShortName { get; set; }
        public string Browser { get; set; }
        public string BrowserShortName { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }
        public int? Support { get; set; }
        public int? Oppose { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
