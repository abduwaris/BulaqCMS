using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.DALService;
using System.Runtime.Remoting.Messaging;

namespace BulaqCMS.BLL
{
    public abstract class BaseService<T>
    {
        public BaseService()
        {
            SetCurrentDAL();
        }

        /// <summary>
        /// 逻辑层操作对象
        /// </summary>
        protected ServiceSession Service
        {
            get
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

        IDALSession _dal;
        protected IDALSession DAL
        {
            get
            {
                if (_dal == null) _dal = DALSessionFactory.CreateDALSession();
                return _dal;
            }
        }

        protected T CurrentDAL { get; set; }

        protected abstract void SetCurrentDAL();
    }
}
