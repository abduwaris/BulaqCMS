﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{

    public enum PostModified
    {
        /// <summary>
        /// 保存
        /// </summary>
        Save,
        /// <summary>
        /// 发表
        /// </summary>
        Send,
        /// <summary>
        /// 设置头贴
        /// </summary>
        Image,
        /// <summary>
        /// 批准
        /// </summary>
        Approve,
        /// <summary>
        /// 删除表示
        /// </summary>
        DelFlag,
        /// <summary>
        /// 草稿
        /// </summary>
        Practice
    }
}