using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler, IRequiresSessionState
    {
        NameValueCollection nv;
        MLMGC.Security.EnterprisePage ep;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ep = new MLMGC.Security.EnterprisePage(true);
            nv = HttpContext.Current.Request.Form;
            switch (nv["key"])
            { 
                case"exist":
                    Exist();
                    break;
                case "active":
                    RefreshOnline();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
            
        }

        /// <summary>
        /// 判断企业用户是否存在
        /// </summary>
        protected void Exist()
        {
            string username = nv["username"];
            int userid = Convert.ToInt32(nv["userid"]);
            if (string.IsNullOrEmpty(username))
            { 
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_User data = new E_User();
            data.EnterpriseID = ep.EnterpriceID;
            data.UserID = userid;
            data.UserName = username;

            bool flag = new T_User().EPUserExist(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        protected void RefreshOnline()
        {
            MLMGC.Security.ActiveUser.Instance.Refresh(ep.UserID.ToString());
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