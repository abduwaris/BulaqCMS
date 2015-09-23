using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    public class ResponseResult
    {
        public string Result { get; set; }

        public List<String> Errors { get; set; }
    }
}