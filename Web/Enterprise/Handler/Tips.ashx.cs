using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net.Json;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using System.Collections.Specialized;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// Tips 的摘要说明
    /// </summary>
    public class Tips : IHttpHandler,IRequiresSessionState
    {
        NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = HttpContext.Current.Request.Form;
            switch (nv["key"])
            { 
                case "Tip":
                    GetTips();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        private void GetTips()
        {
            int menuid;
            int.TryParse(nv["menuid"], out menuid);
            DataTable dt = new T_Menu().GetMenuTipsList(new E_Menu() { MenuID = menuid });
            List<string> list= new List<string> ();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["Tips"].ToString());
            }
            HttpContext.Current.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list));
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