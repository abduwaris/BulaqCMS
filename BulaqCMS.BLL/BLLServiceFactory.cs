using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public abstract class BLLServiceFactory
    {
        /// <summary>
        /// 创建逻辑层操作对象,保持上下文唯一
        /// </summary>
        /// <returns></returns>
        public static ServiceSession CreateServiceSession()
        {
            ServiceSession serviceSession = (ServiceSession)CallContext.GetData("serviceSession");
            if (serviceSession == null)
            {
                serviceSession = new ServiceSession();
                CallContext.SetData("serviceSession", serviceSession);
            }
            return serviceSession;
        }
    }
}
