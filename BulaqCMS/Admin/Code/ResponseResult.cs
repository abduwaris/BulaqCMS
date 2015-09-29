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

        private bool _isSet = false;
        /// <summary>
        ///(只读)是否设置 ResponseResult 用于判断是否设置
        /// </summary>
        [System.Xml.Serialization.SoapIgnore]
        [Newtonsoft.Json.JsonIgnore()]
        //[Newtonsoft.Json.JsonIgnore())]
        public bool IsSet { get { return _isSet; } }

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
            private set
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
            _isSet = true;
            return this;
        }

        /// <summary>
        /// 如果存在错误,表示错误
        /// </summary>
        public string error { get; private set; }

        /// <summary>
        /// 设置返回错误码
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public ResponseResult SetError(string error)
        {
            this.error = error;
            _isSet = true;
            return this;
        }

        /// <summary>
        /// 额外返回参数
        /// </summary>
        public object res { get; private set; }

        /// <summary>
        /// 设置返回res
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public ResponseResult SetRes(object res)
        {
            this.res = res;
            _isSet = true;
            return this;
        }

        /// <summary>
        /// 全部设置
        /// </summary>
        /// <param name="isOk"></param>
        /// <param name="error"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public ResponseResult Set(bool isOk, string error, object res)
        {
            this.res = res;
            this.result = isOk ? "ok" : "no";
            this.error = error;
            _isSet = true;
            return this;
        }
    }
}