using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore
{
    public partial class Userinfo
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public int? Userage { get; set; }
        public int? Sex { get; set; }
        public string Usercount { get; set; }
        public string Userpassword { get; set; }
    }
}
