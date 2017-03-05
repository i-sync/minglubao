using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;
using System.Collections.Specialized;
using System.Net.Json;

namespace WebAdmin.Enterprise.EnterpriseDB
{
    /// <summary>
    /// DB 的摘要说明
    /// </summary>
    public class DB : IHttpHandler
    {
        NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = HttpContext.Current.Request.Form;
            switch (nv["key"])
            { 
                case "defaultflag":
                    DefaultFlag();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        private void DeleteDB()
        {
            int dbid;
            if (!int.TryParse(nv["dbid"], out dbid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }

            E_EnterpriseDB data = new E_EnterpriseDB();
            
        }

        /// <summary>
        /// 设置默认数据库
        /// </summary>
        private void DefaultFlag()
        {
            int dbid;
            if (!int.TryParse(nv["dbid"], out dbid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }

            E_EnterpriseDB data = new E_EnterpriseDB();
            data.EnterpriseDBID = dbid;
            bool flag = new T_EnterpriseDB().UpdateDefaultFlag(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        private void GetModel()
        {
            int dbid;
            if (!int.TryParse(nv["dbid"], out dbid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }

            E_EnterpriseDB data = new E_EnterpriseDB();
            data.EnterpriseDBID = dbid;

            data = new T_EnterpriseDB().GetModel(data);
            if (data == null)
            {
                data = new E_EnterpriseDB();
                data.EnterpriseDBID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.EnterpriseDBID.ToString ()));
            colDR.Add(new JsonStringValue("maxnum", data.MaxNum.ToString ()));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 修改数据库最大容量
        /// </summary>
        private void UpdateMaxNum()
        {
            int dbid,maxnum;
            if (!int.TryParse(nv["dbid"], out dbid) || !int.TryParse(nv["maxnum"],out maxnum))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }

            E_EnterpriseDB data = new E_EnterpriseDB();
            data.EnterpriseDBID = dbid;
            data.MaxNum = maxnum;

            bool flag = new T_EnterpriseDB().UpdateMaxNum(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}