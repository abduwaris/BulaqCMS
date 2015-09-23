using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.DALService
{
    public abstract class DALSessionFactory
    {
        /// <summary>
        /// 保证数据层操作唯一
        /// </summary>
        /// <returns></returns>
        public static IDALSession CreateDALSession()
        {
            IDALSession sess = (IDALSession)CallContext.GetData("DalSession");
            if (sess == null)
            {
                sess = new DALSession();
                CallContext.SetData("DalSession", sess);
            }
            return sess;
        }
    }
}
