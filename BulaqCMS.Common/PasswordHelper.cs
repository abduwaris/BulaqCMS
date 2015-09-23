using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Common
{
    public class PasswordHelper
    {
        /// <summary>
        /// 生成加密密码
        /// </summary>
        /// <param name="input">密码明文</param>
        /// <returns></returns>
        public static string CreateBulaqPassword(string input)
        {
            return StringToMD5(StringToMD5(StringToMD5(input)));
        }
        /// <summary>
        /// 让字符串 MD5 加密
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns></returns>
        public static string StringToMD5(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, input);
                return hash;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }
    }
}
