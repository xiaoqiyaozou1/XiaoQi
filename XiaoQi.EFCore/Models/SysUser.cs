using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class SysUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Qq { get; set; }
        public DateTime? Birthday { get; set; }
        public short? Gender { get; set; }
        public string Avatar { get; set; }
        public string UserType { get; set; }
        public string Company { get; set; }
        public string Blog { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
        public string Uuid { get; set; }
        public byte? Privacy { get; set; }
        public byte? Notification { get; set; }
        public int? Score { get; set; }
        public int? Experience { get; set; }
        public string RegIp { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int? LoginCount { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
