﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoQi.Model
{
    public class MessageModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = true;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "访问成功";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public object response { get; set; }
    }
}
