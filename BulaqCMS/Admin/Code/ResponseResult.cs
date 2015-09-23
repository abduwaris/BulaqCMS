using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    /// <summary>
    /// 数据返回模型
    /// </summary>
    public class ResponseResult
    {
        private string _result = "no";

        /// <summary>
        /// 状态码   ok||no
        /// </summary>
        public string result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        /// <summary>
        /// 设置状态后返回
        /// </summary>
        /// <param name="isOk"></param>
        /// <returns></returns>
        public ResponseResult SetResult(bool isOk = true)
        {
            this._result = isOk ? "ok" : "no";
            return this;
        }

        /// <summary>
        /// 如果存在错误,表示错误
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// 设置返回错误码
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public ResponseResult SetError(string error)
        {
            this.error = error;
            return this;
        }

        /// <summary>
        /// 额外返回参数
        /// </summary>
        public object res { get; set; }

        /// <summary>
        /// 设置返回res
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public ResponseResult SetRes(object res)
        {
            this.res = res;
            return this;
        }
    }
}